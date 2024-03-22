import { Component, EventEmitter, Output } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenService } from "../../../token.service";
import { jwtDecode } from "jwt-decode";
import { environment } from "../../../environment";

@Component({
  selector: 'app-transfer-form',
  templateUrl: './transfer-form.component.html',
  styleUrls: ['./transfer-form.component.css']
})
export class TransferFormComponent {
  destinationAccountNumber: string = '';
  amount: number = 0;
  error: string = '';
  userId: string | null = null;

  @Output() transferComplete = new EventEmitter<{ destinationAccountNumber: string, amount: number }>();

  constructor(public dialogRef: MatDialogRef<TransferFormComponent>, private http: HttpClient, private router: Router, private tokenService: TokenService) {
    const token = this.tokenService.getToken();
    if (token) {
      const decodedToken: any = jwtDecode(token);
      this.userId = decodedToken.sub;
    }
  }

  transfer(): void {
    if (!this.userId) {
      console.error('User ID is not available');
      return;
    }

    const destinationAccountNumberWithoutSpaces = this.destinationAccountNumber.replace(/\s/g, '');
    const transferData = { destinationAccountNumber: destinationAccountNumberWithoutSpaces, amount: this.amount };

    this.http.put(`${environment.apiUrl}/api/transfers/${this.userId}`, transferData)
      .subscribe(
        (response: any) => {
          window.location.reload();
        },
        (error: any) => {
          this.error = 'Error during the transferring!';
        }
      );
  }
}
