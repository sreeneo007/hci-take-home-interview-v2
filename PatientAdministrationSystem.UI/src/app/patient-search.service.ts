import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PatientSearchService {
  private apiUrls = [
    'https://localhost:7260/api/patients/search',
    'http://localhost:5272/api/patients/search'
  ];

  constructor(private http: HttpClient) { }

  searchPatients(query: string): Observable<any[]> {
    return this.tryApiUrls(query, 0);
  }

  private tryApiUrls(query: string, index: number): Observable<any[]> {
    if (index >= this.apiUrls.length) {
      return of([]);
    }

    return this.http.get<any>(`${this.apiUrls[index]}?query=${query}`).pipe(
      map(response => response.$values),
      catchError(() => this.tryApiUrls(query, index + 1))
    );
  }
}