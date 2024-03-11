import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environment';
import { TokenService } from "../../../token.service";
import { jwtDecode } from "jwt-decode";

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css'],
})
export class AccountComponent implements OnInit {
  userFirstName: string | null = null;
  balance: number | null = null;
  userId: string | null = null;

  constructor(private http: HttpClient, private router: Router, private tokenService: TokenService) {}

  ngOnInit(): void {
    const token = this.tokenService.getToken();
    if (token && !this.userFirstName) {
      const decodedToken: any = jwtDecode(token);
      this.userId = decodedToken.sub;
      this.fetchUserData();
      this.fetchBalance();
    }
  }

  fetchUserData(): void {
    this.http.get<any>(`${environment.apiUrl}/user`).subscribe(
      (data) => {
        this.userFirstName = data.userFirstName;
      },
      (error) => {
        console.error('Error fetching user data', error);
        if (error.status === 401) {
          console.error('Token expired or invalid. Redirecting to login page.');
          this.router.navigate(['/login']);
        }
      }
    );
  }

  fetchBalance(): void {
    if (this.userId) {
      this.http.get<any>(`${environment.apiUrl}/api/accounts/${this.userId}/balance`).subscribe(
        (data) => {
          this.balance = data.balance;
        },
        (error) => {
          console.error('Error fetching balance', error);
        }
      );
    } else {
      console.error('User ID is not available');
    }
  }
}
