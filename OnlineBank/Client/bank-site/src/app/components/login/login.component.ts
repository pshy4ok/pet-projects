import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from "../../../environment";
import { TokenService } from '../../../token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  formData: any = {};
  errorMessage: string = '';

  constructor(private router: Router, private http: HttpClient, private tokenService: TokenService) {}

  ngOnInit(): void {}

  onSubmit(): void {
    const { email, password } = this.formData;
    const formData = { email, password };

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    this.http.post(`${environment.apiUrl}/login`, JSON.stringify(formData), { headers: headers, responseType: 'text' })
      .subscribe(
        (token: any) => {
          console.log('Login successful', token);

          this.tokenService.setToken(token);

          this.router.navigate(['/account']);
        },
        (error) => {
          console.error('Login failed', error);
          this.errorMessage = 'Invalid email or password';
        }
      );
  }
}
