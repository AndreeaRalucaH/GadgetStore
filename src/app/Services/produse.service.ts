import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Produse } from 'app/Models/produse.model';

@Injectable({
  providedIn: 'root'
})
export class ProduseService {

  constructor(private http: HttpClient) { }

  readonly prodUrl = "https://localhost:44352/api/produse" 

  postProd(prod: Produse): Observable<Produse>{
    return this.http.post<Produse>(this.prodUrl, prod);
  }

  getAllProds(): Observable<Produse[]>{
    return this.http.get<Produse[]>(this.prodUrl);
  }

  getProd(id: number): Observable<Produse>{
    return this.http.get<Produse>(this.prodUrl + "/" + id);
  }
  
}
