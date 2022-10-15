import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Comenzi } from 'app/Models/comenzi.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ComenziService {

  readonly comUrl = "https://localhost:44352/api/comenzi"
  
  constructor(private http: HttpClient) { }

  postCom(com: Comenzi): Observable<Comenzi>{
    return this.http.post<Comenzi>(this.comUrl, com);
  }
}
