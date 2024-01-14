import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  formData: any = {};
  errorMessage: string = '';

  constructor(private router: Router) {}

  onSubmit(): void {
    const { email, password } = this.formData;

    const formData = { email, password };

    fetch('http://localhost:5269/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(formData),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error('Invalid email or password');
        }
        return response.text();
      })
      .then((data) => {
        console.log('Login successful', data);
        this.router.navigate(['/account', { fullName: data }]);
      })
      .catch((error) => {
        console.error('Login failed', error);
        this.errorMessage = 'Invalid email or password';
      });
  }
}
