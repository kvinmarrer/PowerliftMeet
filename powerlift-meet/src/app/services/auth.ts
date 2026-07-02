import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { jwtDecode } from 'jwt-decode';

export interface User {
  userId: string;
  email: string;
  name: string;
}

@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http: HttpClient, private router: Router) {}

  login(email: string, password: string) {
    return this.http.post<{ token: string }>(`${environment.apiBaseUrl}/auth/login`, { email, password })
      .pipe(tap(res => {
        localStorage.setItem('token', res.token);
      }));
  }

  register(email: string, password: string, name: string) {
    return this.http.post<{ token: string }>(`${environment.apiBaseUrl}/auth/register`, { email, password, name })
      .pipe(tap(res => {
        localStorage.setItem('token', res.token);
      }));
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getUser(): User | null {
    const token = this.getToken();
    if (!token) return null;
    try {
      const decoded: any = jwtDecode(token);
      return {
        userId: decoded.userId,
        email: decoded.email,
        name: decoded.username
      };
    } catch {
      return null;
    }
  }

  loginWithGoogle() {
    window.location.href = `${environment.apiBaseUrl}/auth/google-login`;
  }
  
}