import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { EmployeeDetails, EmployeeListItem } from '../models/employees';
import { ApiResponse } from '../models/response';
import { Filter } from '../models/filters';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private baseURL = environment.apiUrl;

  constructor(private http: HttpClient) {}

  fetchAllEmployees(filters: Filter): Observable<any> {
    return this.http
      .get<ApiResponse>(
        `${
          this.baseURL
        }Employee/GetAllEmployees?searchValue=${filters.searchValue.toString()}&sortColumn=${filters.sortColumn.toString()}&sortDirection=${filters.sortDirection.toString()}`
      )
      .pipe(
        map((response) => {
          if (!response.isSuccess) return [];

          return response.result.map((x) => {
            return {
              checked: false,
              ...x,
            };
          });
        })
      );
  }

  fetchEmployeeByID(employeeID: string): Observable<any> {
    return this.http
      .get<ApiResponse>(`${this.baseURL}Employee/GetEmployee/${employeeID}`)
      .pipe(
        map((response) => {
          if (!response.isSuccess) return null;

          return response.result;
        })
      );
  }

  addNewEmployee(employee: EmployeeDetails) {
    return this.http
      .post<ApiResponse>(`${this.baseURL}Employee/AddNewEmployee/`, employee)
      .pipe(
        map((response) => {
          if (!response.isSuccess) return null;

          return response.result;
        })
      );
  }

  updateEmployee(employee: EmployeeDetails) {
    return this.http
      .put<ApiResponse>(`${this.baseURL}Employee/UpdateEmployee/`, employee)
      .pipe(
        map((response) => {
          if (!response.isSuccess) return null;

          return response.result;
        })
      );
  }

  deleteMultipleEmployees(employeeIDs: string[]): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      body: employeeIDs,
    };

    return this.http
      .delete<ApiResponse>(
        `${this.baseURL}Employee/DeleteMultipleEmployees`,
        httpOptions
      )
      .pipe(
        map((response) => {
          return response.isSuccess;
        })
      );
  }

  deleteEmployee(employeeID: string) {
    return this.http
      .delete<ApiResponse>(
        `${this.baseURL}Employee/DeleteEmployee/${employeeID}`
      )
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
}
