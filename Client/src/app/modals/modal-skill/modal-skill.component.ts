import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { SkillListItem } from 'src/app/models/skill';
import { SkillService } from 'src/app/services/skill.service';

@Component({
  selector: 'app-modal-skill',
  templateUrl: './modal-skill.component.html',
  styleUrls: ['./modal-skill.component.css'],
})
export class ModalSkillComponent implements OnInit {
  @Input() addExistingSkill = new EventEmitter();
  @Input() addNewSkill = new EventEmitter();
  requiredAction: string;
  skillIDs: string[];
  skills: SkillListItem[] = [];
  skillDetailsForm: FormGroup;
  isNewEmployee: boolean;
  skillTypes: any[] = [
    { value: 1, text: 'Soft Skills' },
    { value: 2, text: 'Technical Skills' },
    { value: 3, text: 'Leadership Skills' },
  ];

  constructor(
    public bsModalRef: BsModalRef,
    private service: SkillService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.skillDetailsForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      type: [1, Validators.required],
    });

    this.requiredAction = this.isNewEmployee
      ? 'Save New Employee'
      : 'Update Employee';

    this.service.fetchAllSkills().subscribe((list) => {
      this.skills = list.filter((x) => {
        return this.skillIDs.indexOf(x.skillID) === -1;
      });
    });
  }

  getSkillType(type: number) {
    switch (type) {
      case 1:
        return 'Soft Skills';
      case 2:
        return 'Technical Skills';
      case 3:
        return 'Leadership Skills';
      default:
        return '';
    }
  }

  onAddNewSkill() {
    const skill = { ...this.skillDetailsForm.value };
    this.addNewSkill.emit(skill);
    this.bsModalRef.hide();
  }

  onAddExistingSkill(skill) {
    this.addExistingSkill.emit(skill);
    this.bsModalRef.hide();
  }
}
