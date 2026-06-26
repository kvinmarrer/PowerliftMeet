import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Auth } from '../services/auth';


@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
  standalone: false,
})
export class LoginPage implements OnInit {
  isRegister = false;
  name = '';
  email = '';
  password = '';
  error = '';

  constructor(private auth: Auth, private router: Router) { }

  ngOnInit() {
  }

  submit() {
    if (this.isRegister) {
      this.auth.register(this.email, this.password, this.name).subscribe({
        next: () => {
          this.error = '';
          this.isRegister = false;
        },
        error: (err) => {
          this.error = err.error;
        }
      });
    } else {
      this.auth.login(this.email, this.password).subscribe({
        next: () => {
          this.error = '';
          this.router.navigate(['/tabs/home']);
        },
        error: (err) => {
          this.error = err.error;
        }
      });
    }
  }
}
