import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { ConfirmModalComponent } from 'src/app/modals/confirm-modal/confirm-modal.component';
import { SkillDetails } from 'src/app/models/skill';
import { SkillService } from 'src/app/services/skill.service';

@Component({
  selector: 'app-skill-details',
  templateUrl: './skill-details.component.html',
  styleUrls: ['./skill-details.component.css'],
})
export class SkillDetailsComponent implements OnInit {
  header: string = '';
  skillDetailsForm: FormGroup;
  loading: boolean;
  skillID: string;
  isNewSkill: boolean;
  buttonTitle: string;
  bsModalRef: BsModalRef;
  skillTypes: any[] = [
    { value: 1, text: 'Soft Skills' },
    { value: 2, text: 'Technical Skills' },
    { value: 3, text: 'Leadership Skills' },
  ];

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private service: SkillService,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loading = true;
    this.activatedRoute.params.subscribe((data) => {
      if (data.id === 'addNewSkill') {
        this.setAddNewSkill();
      } else {
        this.setExistingSkill(data.id);
      }
    });
  }

  setAddNewSkill() {
    this.buttonTitle = 'Save New Skill';
    this.header = `Add New Skill`;
    this.isNewSkill = true;
    this.skillDetailsForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      type: [1, Validators.required],
    });
    this.loading = false;
  }

  setExistingSkill(skillID: string) {
    this.isNewSkill = false;
    this.service.fetchSkillByID(skillID).subscribe(
      (x) => {
        this.skillID = x.skillID;
        this.buttonTitle = 'Update Skill';
        this.header = `Skill: ${x.title}`;
        this.skillDetailsForm = this.fb.group({
          title: [x.title, Validators.required],
          description: [x.description, Validators.required],
          type: [x.type, Validators.required],
        });
      },
      () => {},
      () => {
        this.loading = false;
      }
    );
  }

  deleteSkill() {
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        title: 'Delete current skill',
        content: 'Are you sure that you want to delete the current skill?',
      },
    };
    this.bsModalRef = this.modalService.show(ConfirmModalComponent, config);
    this.bsModalRef.content.closeBtnName = 'Close';

    this.bsModalRef.content.deleteSelectedRecord.subscribe(() => {
      this.service.deleteSkill(this.skillID).subscribe(
        (result) => {
          if (result.isSuccess) {
            this.toastr.success(
              'Skill was deleted successfully. You will be redirected to Skill List page in 2 seconds'
            );
            setTimeout(() => {
              this.router.navigateByUrl('/skills');
            }, 2000);
          } else {
            this.toastr.error(
              'Skill was not deleted successfully. Please try again.'
            );
          }
        },
        () => {
          this.toastr.error('An unexpected error occured.');
        }
      );
    });
  }

  saveSkill() {
    if (this.isNewSkill) this.addNewSkill();
    else this.updateCurrentSkill();
  }

  addNewSkill() {
    const skillObject: SkillDetails = {
      skillID: null,
      title: this.skillDetailsForm.value['title'],
      description: this.skillDetailsForm.value['description'],
      type: Number(this.skillDetailsForm.value['type']),
    };

    this.service.addNewSkill(skillObject).subscribe(
      (result) => {
        if (result) {
          this.toastr.success(
            'Skill was added successfully. You will be redirected to Skill List page in 2 seconds'
          );
          setTimeout(() => {
            this.router.navigateByUrl('/skills');
          }, 2000);
        } else {
          this.toastr.error(
            'Skill was not added successfully. Please try again.'
          );
        }
      },
      () => {
        this.toastr.error('An unexpected error occured.');
      }
    );
  }

  updateCurrentSkill() {
    const skillObject: SkillDetails = {
      skillID: this.skillID,
      title: this.skillDetailsForm.value['title'],
      description: this.skillDetailsForm.value['description'],
      type: Number(this.skillDetailsForm.value['type']),
    };

    this.service.updateSkill(skillObject).subscribe(
      (result) => {
        if (result) {
          this.toastr.success('Skill was updated successfully.');
        } else {
          this.toastr.error(
            'Skill was not updated successfully. Please try again.'
          );
        }
      },
      () => {
        this.toastr.error('An unexpected error occured.');
      }
    );
  }
}
