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
      if (typeof document !== 'undefined') {
        const name = 'access_token' + '=';
        const decodedCookie = decodeURIComponent(document.cookie);
        const cookieArray = decodedCookie.split(';');

        for (let i = 0; i < cookieArray.length; i++) {
          let cookie = cookieArray[i];
          while (cookie.charAt(0) === ' ') {
            cookie = cookie.substring(1);
          }
          if (cookie.indexOf(name) === 0) {
            return cookie.substring(name.length, cookie.length);
          }
        }
      }
      return null;
    }

  clearToken(): void {
    document.cookie = `${this.TOKEN_KEY}=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/`;
    console.log('Token cleared.');
    console.log('Cookie cleared.');
  }

    isTokenValid(): boolean {
        const token = this.getToken();
        if (!token) return false;

        const expirationDate = new Date();
        const tokenExpiration = new Date(expirationDate.getTime() + 60 * 60 * 1000);
        return tokenExpiration > new Date();
    }
}
