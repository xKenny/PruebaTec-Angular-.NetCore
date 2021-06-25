import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LibroServService {

  private myAppUrl = 'https://localhost:44300/';
  private myApiUrl = 'api/Libros/';

  constructor(private http:HttpClient) { }

  getListLibros(): Observable<any> {
    return this.http.get(this.myAppUrl + this.myApiUrl);
  }

  deleteLibro(id: number): Observable<any>{
      return this.http.delete(this.myAppUrl + this.myApiUrl + id)
  }

  saveLibro(libro : any): Observable<any>{
      return this.http.post(this.myAppUrl + this.myApiUrl, libro);
  }
}
