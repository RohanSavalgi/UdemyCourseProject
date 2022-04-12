import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { student } from '../models/api-models/student.model';
import { updateStudentRequest } from '../models/api-models/update-student-request.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private baseApiUrl = environment.baseApiUrl;

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

  addStudent(studentRequest: student) : Observable<student>
  {
    const updateStudentModel: updateStudentRequest = {
      firstName: studentRequest.firstName,
      lastName: studentRequest.lastName,
      dateOfBirth: studentRequest.dateOfBirth,
      email: studentRequest.email,
      mobile: studentRequest.mobile,
      genderId: studentRequest.genderId,
      physicalAddress: studentRequest.address.physicalAddress,
      postalAddress: studentRequest.address.postalAddress,
      profileImageUrl: studentRequest.profileImageUrl
    }
    return this.httpClient.post<student>(this.baseApiUrl + "/Student/Add",updateStudentModel);
  }

  updateStudent(studentId: string, studentRequest: student) : Observable<student>
  {
    const updateStudentModel: updateStudentRequest = {
      firstName: studentRequest.firstName,
      lastName: studentRequest.lastName,
      dateOfBirth: studentRequest.dateOfBirth,
      email: studentRequest.email,
      mobile: studentRequest.mobile,
      genderId: studentRequest.genderId,
      physicalAddress: studentRequest.address.physicalAddress,
      postalAddress: studentRequest.address.postalAddress,
      profileImageUrl: studentRequest.profileImageUrl
    }
    return this.httpClient.put<student>(this.baseApiUrl + "/Student/" + studentId,updateStudentModel);
  }
}
