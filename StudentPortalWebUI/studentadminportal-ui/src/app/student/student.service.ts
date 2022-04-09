import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { student } from '../models/api-models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private baseApiUrl = "https://localhost:44393";

  constructor(private httpClient : HttpClient) { }

  getStudents() : Observable<student[]>
  {
    return this.httpClient.get<student[]>(this.baseApiUrl + "/Student")
  }

  getStudent(studentId: string): Observable<student>
  {
    return this.httpClient.get<student>(this.baseApiUrl + "/student/" + studentId);
  }

  deleteStudent(studentId: string): Observable<student>
  {
    return this.httpClient.delete<student>(this.baseApiUrl + "/Student/" + studentId);
  }

  addStudent(pass: student) : Observable<student>
  {
    return this.httpClient.post<student>(this.baseApiUrl + "/Student/Add",pass);
  }

}
