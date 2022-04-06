import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { gender } from '../models/ui-models/gender.model';

@Injectable({
  providedIn: 'root'
})
export class GenderService {

  private baseApiUrl = "https://localhost:44393";

  constructor(private httpClient: HttpClient) { }

  getGenders() : Observable<gender[]>
  {
    return this.httpClient.get<gender[]>(this.baseApiUrl + "/gender");
  }
}
