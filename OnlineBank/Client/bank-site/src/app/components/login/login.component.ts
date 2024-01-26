import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from "../../../environment";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  formData: any = {};
  errorMessage: string = '';

  constructor(private router: Router, private http: HttpClient) {}

  onSubmit(): void {
    const { email, password } = this.formData;

    const formData = { email, password };

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    this.http.post(`${environment.apiUrl}/login`, JSON.stringify(formData), { headers: headers })
      .subscribe(
        (data: any) => {
          console.log('Login successful', data);
          this.router.navigate(['/account', { firstName: data }]);
        },
        (error) => {
          console.error('Login failed', error);
          this.errorMessage = 'Invalid email or password';
        }
      );
  }
}
