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
  accountNumber: number | null = null;
  userId: string | null = null;

  constructor(private http: HttpClient, private router: Router, private tokenService: TokenService) {}

  ngOnInit(): void {
      if (!this.tokenService.isTokenValid()) {
          console.error('Token expired or not available. Redirecting to login page.');
          this.router.navigate(['/login']);
          return;
      }

    const token = this.tokenService.getToken();
    if (token && !this.userFirstName) {
      const decodedToken: any = jwtDecode(token);
      this.userId = decodedToken.sub;
      this.fetchUserData();
      this.fetchAccountData();
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

  fetchAccountData(): void {
    if (this.userId) {
      this.http.get<any>(`${environment.apiUrl}/api/accounts/${this.userId}/account`).subscribe(
        (data) => {
          this.accountNumber = data.accountNumber;
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

    formatAccountNumber(accountNumber: number | null): string {
        if (!accountNumber) return '';
        const accountNumberString = accountNumber.toString();
        const groups = accountNumberString.match(/.{1,4}/g);
        if (!groups) return '';
        return groups.join(' ');
    }

  formatBalance(balance: number | null): string {
    if (balance == null) return '';
    const formattedBalance = balance.toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ' ');
    return formattedBalance;
  }
}
