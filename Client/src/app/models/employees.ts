import { SkillDetails } from './skill';

export interface EmployeeListItem {
  checked: boolean;
  employeeID: string;
  firstName: string;
  lastName: string;
  hiringDate: Date;
  jobTitle: string;
}

export interface EmployeeDetails {
  employeeID: string;
  firstName: string;
  lastName: string;
  hiringDate: Date;
  jobTitle: string;
  email: string;
  dateOfBirth: Date;
  employeeType: number;
  skills: EmployeeSkills[];
}

export interface EmployeeSkills {
  skillID: string;
  skill: SkillDetails;
}
