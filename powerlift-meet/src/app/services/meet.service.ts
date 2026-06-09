import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class MeetService {
  private apiUrl = `${environment.apiBaseUrl}/meet`;

  constructor(private http: HttpClient) {}

  getMeets() {
    return this.http.get<string[]>(this.apiUrl);
  }
}