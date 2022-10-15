import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DetaliiComenzi } from 'app/Models/detalii-comenzi.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class DetaliiComandaService {

  readonly comUrl = "https://localhost:44352/api/detaliicomenzi"
  
  constructor(private http: HttpClient) { }

  postComDet(com: DetaliiComenzi): Observable<DetaliiComenzi>{
    return this.http.post<DetaliiComenzi>(this.comUrl, com);
  }

  getDetaliiCom(): Observable<DetaliiComenzi[]>{
    return this.http.get<DetaliiComenzi[]>(this.comUrl)
  }

  update(id: number, com: DetaliiComenzi):Observable<DetaliiComenzi>{

    return this.http.put<DetaliiComenzi>(this.comUrl + "/" + id,com)
  }
}
