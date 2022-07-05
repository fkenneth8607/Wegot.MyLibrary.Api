import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Book } from '../Models/Book';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BooksService {


  private headers = {}
  constructor(private httpClient: HttpClient) {
    let headers = new HttpHeaders({
      'Access-Control-Allow-Origin': 'http://localhost:4200',
      'Access-Control-Allow-Methods': 'POST, GET, PUT, OPTIONS, DELETE',
      'Access-Control-Allow-Headers': 'x-requested-with, content-type',
      token: ''
    })
    this.headers = { headers: headers}
  }

  private apiUrl = environment.API_URL + 'books/';
 

  // Show lists of item
  list(): Observable<any> {
    return this.httpClient.get(this.apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // Create new item
  getItem(id: number): Observable<any> {
    return this.httpClient.get(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  create(data: Book): Observable<any> {
    return this.httpClient.post(this.apiUrl, data).pipe(
      catchError(this.handleError)
    );
  }

  // Edit/ Update 
  update(id: number, data: Book): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${id}`, data).pipe(
      catchError(this.handleError)
    );
  }

  // Delete
  delete(id: number): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`).pipe(
      catchError(this.handleError)
    );
  }
 
  // Handle API errors
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  };

}