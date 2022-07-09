import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmModalComponent } from 'src/app/modals/confirm-modal/confirm-modal.component';
import { EmployeeListItem } from 'src/app/models/employees';
import { Filter } from 'src/app/models/filters';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  loading: boolean;
  bsModalRef: BsModalRef;
  filterValue: Filter = {
    searchValue: '',
    sortColumn: '',
    sortDirection: '',
  };
  employeeList: EmployeeListItem[] = [];
  toastr: any;

  constructor(
    private service: EmployeeService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.loadEmployees(true);
  }

  loadEmployees(avoidLoading: boolean) {
    if (avoidLoading) this.loading = true;
    this.service.fetchAllEmployees(this.filterValue).subscribe(
      (list) => {
        this.employeeList = list;
      },
      () => {
        this.employeeList = [];
      },
      () => {
        if (avoidLoading) this.loading = false;
      }
    );
  }

  orderBy(column: string) {
    if (this.filterValue.sortColumn === column) {
      if (this.filterValue.sortDirection === 'ASC')
        this.filterValue.sortDirection = 'DESC';
      else if (this.filterValue.sortDirection === 'DESC')
        this.filterValue.sortDirection = 'ASC';
      else this.filterValue.sortDirection = 'DESC';
    } else {
      this.filterValue.sortColumn = column;
      this.filterValue.sortDirection = 'ASC';
    }

    this.loadEmployees(false);
  }

  submitSearch() {
    this.loadEmployees(false);
  }

  resetFilters() {
    this.filterValue.sortColumn = '';
    this.filterValue.sortDirection = '';
    this.filterValue.searchValue = '';
    this.loadEmployees(false);
  }

  deleteMultipleEmployees() {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        title: 'Delete selected employees',
        content: 'Are you sure that you want to delete the selected employees?',
      },
    };
    this.bsModalRef = this.modalService.show(ConfirmModalComponent, config);
    this.bsModalRef.content.closeBtnName = 'Close';

    this.bsModalRef.content.deleteSelectedRecord.subscribe(() => {
      const selectedEmployeeIDs = this.employeeList
        .filter((x) => x.checked)
        .map((x) => x.employeeID);

      this.service.deleteMultipleEmployees(selectedEmployeeIDs).subscribe(
        (result) => {
          if (result) {
            this.employeeList = this.employeeList.filter((x) => !x.checked);
            this.toastr.success(
              'Selected employees were deleted successfully.'
            );
          } else {
            this.toastr.error(
              'Selected employees were not deleted successfully. Please try again.'
            );
          }
        },
        () => {
          this.toastr.error('An unexpected error occured.');
        }
      );
    });
  }

  checkSelectedRecords() {
    return this.employeeList.filter((x) => x.checked).length === 0;
  }

  checkFilters() {
    return (
      this.filterValue.searchValue === '' &&
      this.filterValue.sortColumn === '' &&
      this.filterValue.sortDirection === ''
    );
  }
}
