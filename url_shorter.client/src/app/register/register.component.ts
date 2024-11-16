import { Component } from '@angular/core';
import { AuthService } from '../services/AuthService';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  email = '';
  password = '';
  confirmPassword = '';
  isAdmin = false;

  constructor(private authService: AuthService) { }

  onRegister() {
    if (this.password !== this.confirmPassword) {
      alert('Passwords do not match!');
      return;
    }

    const registerData = {
      email: this.email,
      password: this.password,
      admin: this.isAdmin
    };

    this.authService.register(registerData).subscribe(
      response => {
        alert('Registration successful!');
      },
      error => {
        console.error('Error during registration', error);
        alert('Registration failed!');
      }
    );
  }
}
