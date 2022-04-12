import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { gender } from '../models/ui-models/gender.model';

@Injectable({
  providedIn: 'root'
})
export class GenderService {

  private baseApiUrl = environment.baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getGenders() : Observable<gender[]>
  {
    return this.httpClient.get<gender[]>(this.baseApiUrl + "/gender");
  }
}
