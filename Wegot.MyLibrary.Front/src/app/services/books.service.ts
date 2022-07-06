import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Book } from '../Models/Book';
import { environment } from 'src/environments/environment';
import { ResponseData } from '../Models/ResponseData';

@Injectable({
  providedIn: 'root'
})
export class BooksService {


  private headers = {};
  constructor(private httpClient: HttpClient) {
    let headers =  {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': 'http://localhost:4200',
      'Access-Control-Allow-Methods': 'POST, GET, PUT, OPTIONS, DELETE',
      'Access-Control-Allow-Headers': 'x-requested-with, content-type',
    }
    this.headers = { headers:   headers};
  }

  private apiUrl = environment.API_URL + 'books';
 
 
  // Show lists of item
  getAll(): Observable<ResponseData> {
    return this.httpClient.get<ResponseData>(this.apiUrl, this.headers);
  }

  // Create new item
  getById(id: number): Observable<ResponseData> {
    return this.httpClient.get<ResponseData>(`${this.apiUrl}/${id}`, this.headers);
  }

  create(data: Book): Observable<ResponseData> {
    return this.httpClient.post<ResponseData>(this.apiUrl, data, this.headers);
  }

  // Edit/ Update 
  update(id: number, data: Book): Observable<ResponseData> {
    return this.httpClient.put<ResponseData>(`${this.apiUrl}`, data, this.headers);
  }

  // Delete
  delete(id: number): Observable<ResponseData> {
    return this.httpClient.delete<ResponseData>(`${this.apiUrl}/${id}`, this.headers);
  }

}