import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private readonly TOKEN_KEY = 'access_token';

  constructor() {}

  setToken(token: string): void {
    const expirationDate = new Date();
    expirationDate.setHours(expirationDate.getHours() + 1);
    document.cookie = `${this.TOKEN_KEY}=${token}; expires=${expirationDate.toUTCString()}; path=/`;
    console.log('Token set. Expires at:', expirationDate.toLocaleString());
    console.log('Cookie set. Expires at:', expirationDate.toLocaleString());
  }

  getToken(): string | null {
    const cookies = document.cookie.split(';');
    for (let cookie of cookies) {
      const [name, value] = cookie.trim().split('=');
      if (name === this.TOKEN_KEY) {
        return value;
      }
    }
    return null;
  }

  clearToken(): void {
    document.cookie = `${this.TOKEN_KEY}=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/`;
    console.log('Token cleared.');
    console.log('Cookie cleared.');
  }
}
