import { Component } from '@angular/core';
import { AuthService } from '../services/AuthService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService) { }

  onLogin() {
    this.authService.login({ email: this.email, password: this.password })
      .subscribe(response => {
        console.log('User login successfully', response);
        alert('Login succesfull')
      }, error => {
        console.error('Login failed', error);
      });
  }
}
