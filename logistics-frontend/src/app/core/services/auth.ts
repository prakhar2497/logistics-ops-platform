import { Injectable } from '@angular/core';
import { HttpBase } from './http-base';
import { Token } from '../../shared/model/token.model';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http: HttpBase) {}

  login(email: string, password: string) {
    console.log('Auth Service - Login called');
    return this.http.post<Token>('auth/login', { email, password });
  }
}
