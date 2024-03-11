import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from "../../../environment";
import { TokenService } from '../../../token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  formData: any = {
    rememberMe: false
  };
  errorMessage: string = '';

  constructor(private router: Router, private http: HttpClient, private tokenService: TokenService) {}

  ngOnInit(): void {
    if (typeof localStorage !== 'undefined') {
      const storedEmail = localStorage.getItem('rememberedEmail');
      const storedPassword = localStorage.getItem('rememberedPassword');
      if (storedEmail && storedPassword) {
        this.formData.email = storedEmail;
        this.formData.password = storedPassword;
        this.formData.rememberMe = true;
      }
    }
  }

  onSubmit(): void {
    const { email, password, rememberMe } = this.formData;
    const formData = { email, password };

    if (rememberMe) {
      localStorage.setItem('rememberedEmail', email);
      localStorage.setItem('rememberedPassword', password);
    } else {
      localStorage.removeItem('rememberedEmail');
      localStorage.removeItem('rememberedPassword');
    }

    this.http.post<any>(`${environment.apiUrl}/login`, formData)
      .subscribe(
        (response: any) => {
          console.log('Login successful', response);

          const token = response.accessToken;

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
