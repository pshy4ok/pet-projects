import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environment';
import { TokenService } from "../../../token.service";

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css'],
})
export class AccountComponent implements OnInit {
  userFirstName: string | null = null;
  isLoading: boolean = true;

  constructor(private http: HttpClient, private router: Router, private tokenService: TokenService) {}

  ngOnInit(): void {
    const token = this.tokenService.getToken();
    if (token && !this.userFirstName) {
      this.fetchUserData();
    }
  }

  fetchUserData(): void {
    this.http.get<any>(`${environment.apiUrl}/user`).subscribe(
      (data) => {
        this.userFirstName = data.userFirstName;
        this.isLoading = false;
      },
      (error) => {
        console.error('Error fetching user data', error);
        if (error.status === 401) {
          console.error('Token expired or invalid. Redirecting to login page.');
          this.router.navigate(['/login']);
        }
        this.isLoading = false;
      }
    );
  }
}
