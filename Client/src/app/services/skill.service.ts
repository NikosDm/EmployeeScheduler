import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../models/response';
import { SkillDetails, SkillListItem } from '../models/skill';

@Injectable({
  providedIn: 'root',
})
export class SkillService {
  private baseURL = environment.apiUrl;

  constructor(private http: HttpClient) {}

  fetchAllSkills(): Observable<SkillListItem[]> {
    return this.http.get<ApiResponse>(`${this.baseURL}Skill/GetAllSkills`).pipe(
      map((response) => {
        if (!response.isSuccess) return [];

        return response.result;
      })
    );
  }

  fetchSkillByID(skillID: string): Observable<any> {
    return this.http
      .get<ApiResponse>(`${this.baseURL}Skill/GetSKill/${skillID}`)
      .pipe(
        map((response) => {
          if (!response.isSuccess) return null;

          return response.result;
        })
      );
  }

  addNewSkill(skill: SkillDetails) {
    return this.http
      .post<ApiResponse>(`${this.baseURL}Skill/AddNewSkill/`, skill)
      .pipe(
        map((response) => {
          if (!response.isSuccess) return null;

          return response.result;
        })
      );
  }

  updateSkill(skill: SkillDetails) {
    return this.http
      .put<ApiResponse>(`${this.baseURL}Skill/UpdateSkill/`, skill)
      .pipe(
        map((response) => {
          if (!response.isSuccess) return null;

          return response.result;
        })
      );
  }

  deleteSkill(skillID) {
    return this.http
      .delete<ApiResponse>(`${this.baseURL}Skill/DeleteSkill/${skillID}`)
      .pipe(
        map((response) => {
          return response;
        })
      );
  }

  exportSkills() {
    return this.http.get(`${this.baseURL}Skill/ExportSkillsToExcel`, {
      responseType: 'blob',
    });
  }
}
