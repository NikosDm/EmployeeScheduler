import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SkillDetailsComponent } from './skills/skill-details/skill-details.component';
import { SkillListComponent } from './skills/skill-list/skill-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'employees', component: EmployeeListComponent },
  { path: 'employees/:id', component: EmployeeDetailComponent },
  { path: 'employees/addNewEmployee', component: EmployeeDetailComponent },
  { path: 'skills', component: SkillListComponent },
  { path: 'skills/:id', component: SkillDetailsComponent },
  { path: 'skills/addNewSkill', component: SkillDetailsComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
