import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environment';
import { TokenService } from '../../../token.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css'],
})
export class AccountComponent implements OnInit {
  userName: string | null = null;

  constructor(private http: HttpClient, private router: Router, private tokenService: TokenService) {}

  ngOnInit(): void {
    const token = this.tokenService.getToken();

    if (token) {
      const headers = new HttpHeaders({
        'Authorization': `Bearer ${token}`
      });

      this.http.get(`${environment.apiUrl}/user`, { headers, responseType: 'text' }).subscribe(
        (data) => {
          this.userName = data as string;
        },
        (error) => {
          console.error('Error fetching user data', error);
          if (error.status === 401) {
            console.error('Token expired or invalid. Redirecting to login page.');
            this.tokenService.clearToken();
            this.router.navigate(['/login']);
          }
        }
      );
    } else {
      console.error('Token not found');
      this.router.navigate(['/login']);
    }
  }
}
