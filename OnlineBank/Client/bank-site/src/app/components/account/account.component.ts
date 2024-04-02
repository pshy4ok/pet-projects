import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environment';
import { TokenService } from "../../../token.service";
import { jwtDecode } from "jwt-decode";
import { MatDialog } from '@angular/material/dialog';
import { TransferFormComponent } from "../transfer-form/transfer-form.component";

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
  showTransferForm: boolean = false;

  constructor(private http: HttpClient, private router: Router, private tokenService: TokenService, private dialog: MatDialog) {}

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

  openTransferForm(): void {
    this.showTransferForm = true;
    const dialogRef = this.dialog.open(TransferFormComponent);

    dialogRef.componentInstance.transferComplete.subscribe((transferData: any) => {
      this.fetchAccountData();
    });

    dialogRef.afterClosed().subscribe(result => {
      this.showTransferForm = false;
    });
  }
}
