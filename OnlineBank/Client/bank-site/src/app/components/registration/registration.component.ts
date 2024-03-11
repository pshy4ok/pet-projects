import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from "../../../environment";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class RegistrationComponent {
  formData: any = {};
  errorMessage: string = '';

  constructor(private router: Router, private http: HttpClient) {}

  onSubmit(form: any): void {
    const firstName = this.formData.firstName;
    const lastName = this.formData.lastName;
    const email = this.formData.email;
    const password = this.formData.password;
    const repeatPassword = this.formData.repeatPassword;

    if (password !== repeatPassword) {
      this.errorMessage = "Password do not match!";
      return;
    }

    const formData = {
      firstName: firstName,
      lastName: lastName,
      email: email,
      password: password
    };

    this.http.post(`${environment.apiUrl}/signup`, formData)
      .subscribe(
        (data: any) => {
          console.log('Registration successful', data);
          this.router.navigate(['/login']);
        },
        (error) => {
          this.errorMessage = "Something went wrong. Try again!";
          console.error('Registration failed', error);
        }
      );
  }
}
