import { Component, OnInit } from '@angular/core';
import { SkillListItem } from 'src/app/models/skill';
import { SkillService } from 'src/app/services/skill.service';

@Component({
  selector: 'app-skill-list',
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.css'],
})
export class SkillListComponent implements OnInit {
  loading: boolean;
  skills: SkillListItem[] = [];

  constructor(private service: SkillService) {}

  ngOnInit(): void {
    this.loadSkills();
  }

  loadSkills() {
    this.loading = true;
    this.service.fetchAllSkills().subscribe(
      (list) => {
        this.skills = list;
      },
      () => {
        this.skills = [];
      },
      () => {
        this.loading = false;
      }
    );
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
}
