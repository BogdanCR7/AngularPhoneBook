import { HttpClient } from '@angular/common/http';
import { flatten } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, tap } from 'rxjs';
import { Token } from '../models/token';

@Injectable({
  providedIn: 'root',
})
//npm install @auth0/angular-jwt
export class AuthService {
  private baseurl = 'https://localhost:44386';
  constructor(
    private http: HttpClient,
    private jwthelper: JwtHelperService,
    private routing: Router
  ) {}
  login(email: string, password: string): Observable<Token> {
    this.http
      .post<any>('https://localhost:44386/api/auth/login', {
        email: email,
        password: password,
      })
      .subscribe((data) => {
        localStorage.setItem('access_token', data.access_token);
        this.routing.navigate(['contacts']);
      });
    return localStorage.getItem('access_token') as any;
  }
  islogin(): boolean {
    let token = localStorage.getItem('access_token');
    if (token && !this.jwthelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  }
  logout(): void {
    localStorage.removeItem('access_token');
    this.routing.navigate(['']);
  }
}
