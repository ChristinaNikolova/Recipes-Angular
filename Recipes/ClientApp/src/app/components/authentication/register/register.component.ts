import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth/auth.service';

const USERNAME_MIN_LEN = 3;
const PASS_MIN_LEN = 5;

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registerForm: FormGroup;

  constructor(
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(USERNAME_MIN_LEN)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(PASS_MIN_LEN)]],
      repeatPassword: ['', [Validators.required]]
    });
  }

  public signUp() {
    if (this.registerForm.invalid) {
      return;
    }

    this.authService
      .register(this.registerForm.value)
      .subscribe(() => {
        this.router.navigate(['/login'])
      });
  }

  public get f() {
    return this.registerForm.controls;
  }
}
