import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ConfirmModalComponent } from 'src/app/modals/confirm-modal/confirm-modal.component';
import { EmployeeDetails } from 'src/app/models/employees';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css'],
})
export class EmployeeDetailComponent implements OnInit {
  header: string = '';
  employeeDetailsForm: FormGroup;
  bsModalRef: BsModalRef;
  employeeID: string;
  loading: boolean;
  employmentTypes: any[] = [
    { value: 1, text: 'Full Time' },
    { value: 2, text: 'Part Time' },
    { value: 3, text: 'Temporary' },
    { value: 4, text: 'Internship' },
  ];
  isNewEmployee: boolean;
  buttonTitle: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private service: EmployeeService,
    private router: Router,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.loading = true;
    this.activatedRoute.params.subscribe((data) => {
      if (data.id === 'addNewEmployee') {
        this.setAddNewEmployee();
      } else {
        this.setExistingEmployee(data.id);
      }
    });
  }

  setAddNewEmployee() {
    this.buttonTitle = 'Save New Employee';
    this.header = `Add New Employee`;
    this.isNewEmployee = true;
    this.employeeDetailsForm = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['', [Validators.required, Validators.email]],
      DateOfBirth: ['', Validators.required],
      HiringDate: ['', Validators.required],
      EmploymentType: [1, Validators.required],
      JobTitle: ['', Validators.required],
    });
    this.loading = false;
  }

  setExistingEmployee(employeeID: string) {
    this.isNewEmployee = false;
    this.service.fetchEmployeeByID(employeeID).subscribe(
      (x) => {
        this.employeeID = employeeID;
        this.buttonTitle = 'Update Employee';
        this.header = `Employee ${x.firstName} ${x.lastName}`;
        this.employeeDetailsForm = this.fb.group({
          FirstName: [x.firstName, Validators.required],
          LastName: [x.lastName, Validators.required],
          Email: [x.email, [Validators.required, Validators.email]],
          DateOfBirth: [new Date(x.dateOfBirth), Validators.required],
          HiringDate: [new Date(x.hiringDate), Validators.required],
          EmploymentType: [x.employeeType, Validators.required],
          JobTitle: [x.jobTitle, Validators.required],
        });
      },
      () => {},
      () => {
        this.loading = false;
      }
    );
  }

  deleteEmployee() {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        title: 'Delete current employee',
        content: 'Are you sure that you want to delete the current employee?',
      },
    };
    this.bsModalRef = this.modalService.show(ConfirmModalComponent, config);
    this.bsModalRef.content.closeBtnName = 'Close';

    this.bsModalRef.content.deleteSelectedRecord.subscribe(() => {
      this.service.deleteEmployee(this.employeeID).subscribe(
        (result) => {
          if (result.isSuccess) {
            this.toastr.success(
              'Employee was deleted successfully. You will be redirected to Employee List page in 2 seconds'
            );
            setTimeout(() => {
              this.router.navigateByUrl('/employees');
            }, 2000);
          } else {
            this.toastr.error(
              'Employee was not deleted successfully. Please try again.'
            );
          }
        },
        () => {
          this.toastr.error('An unexpected error occured.');
        }
      );
    });
  }

  saveEmployee() {
    if (this.isNewEmployee) this.addNewEmployee();
    else this.updateCurrentSkill();
  }

  addNewEmployee() {
    const employeeObject: EmployeeDetails = {
      employeeID: null,
      firstName: this.employeeDetailsForm.value['FirstName'],
      lastName: this.employeeDetailsForm.value['LastName'],
      email: this.employeeDetailsForm.value['Email'],
      dateOfBirth: this.employeeDetailsForm.value['DateOfBirth'],
      hiringDate: this.employeeDetailsForm.value['HiringDate'],
      employeeType: Number(this.employeeDetailsForm.value['EmploymentType']),
      jobTitle: this.employeeDetailsForm.value['JobTitle'],
    };

    this.service.addNewEmployee(employeeObject).subscribe(
      (result) => {
        if (result) {
          this.toastr.success(
            'Employee was added successfully. You will be redirected to Employee List page in 2 seconds'
          );
          setTimeout(() => {
            this.router.navigateByUrl('/employees');
          }, 2000);
        } else {
          this.toastr.error(
            'Employee was not added successfully. Please try again.'
          );
        }
      },
      () => {
        this.toastr.error('An unexpected error occured.');
      }
    );
  }

  updateCurrentSkill() {
    const employeeObject: EmployeeDetails = {
      employeeID: this.employeeID,
      firstName: this.employeeDetailsForm.value['FirstName'],
      lastName: this.employeeDetailsForm.value['LastName'],
      email: this.employeeDetailsForm.value['Email'],
      dateOfBirth: this.employeeDetailsForm.value['DateOfBirth'],
      hiringDate: this.employeeDetailsForm.value['HiringDate'],
      employeeType: Number(this.employeeDetailsForm.value['EmploymentType']),
      jobTitle: this.employeeDetailsForm.value['JobTitle'],
    };

    this.service.updateEmployee(employeeObject).subscribe(
      (result) => {
        if (result) {
          this.toastr.success('Employee was updated successfully.');
        } else {
          this.toastr.error(
            'Employee was not added successfully. Please try again.'
          );
        }
      },
      () => {
        this.toastr.error('An unexpected error occured.');
      }
    );
  }
}
