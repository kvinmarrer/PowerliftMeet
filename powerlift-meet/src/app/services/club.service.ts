import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface Club {
  id: string;
  name: string;
  description: string;
}

@Injectable({ providedIn: 'root' })
export class ClubService {
    
  private apiUrl = `${environment.apiBaseUrl}/club`;

  constructor(private http: HttpClient) {}

  getClubs() {
    return this.http.get<Club[]>(this.apiUrl);
  }

}