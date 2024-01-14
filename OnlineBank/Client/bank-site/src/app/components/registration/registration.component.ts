import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class RegistrationComponent {
  formData: any = {};
  errorMessage: string = '';

  constructor(private router: Router) {}

  onSubmit(form: any): void {
    const fullname = this.formData.fullname;
    const email = this.formData.email;
    const password = this.formData.password;
    const rpassword = this.formData.rpassword;

    const formData = {
      fullname: fullname,
      email: email,
      password: password,
    };

    fetch('http://localhost:5269/registration', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(formData),
    })
      .then((response) => {
        if (!response.ok) {
          this.errorMessage = "Something went wrong. Try again!";
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then((data) => {
        console.log('Registration successful', data);
        this.router.navigate(['/login']);
      })
      .catch((error) => {
        this.errorMessage = "Something went wrong. Try again!";
        console.error('Registration failed', error);
      });
  }
}
