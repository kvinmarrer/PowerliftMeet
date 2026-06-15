import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface Gender {
  id: string;
  name: string;
}

@Injectable({ providedIn: 'root' })
export class GenderService {
  private apiUrl = `${environment.apiBaseUrl}/gender`;

  constructor(private http: HttpClient) {}

  getGenders() {
    return this.http.get<Gender[]>(this.apiUrl);
  }
  
}