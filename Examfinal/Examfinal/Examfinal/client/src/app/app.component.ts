import { Component } from '@angular/core';
import {AuthService} from './services/auth.service'
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';

  public  isLoggedIn(): boolean {

    return this.Auth.islogin();
  }
  checkoutForm = this.formBuilder.group({
    email: '',
    password: ''
  });
  constructor(private Auth: AuthService,private formBuilder: FormBuilder,private router: Router) {
    if (this.Auth.islogin()) {
      this.router.navigate(['contacts']);
  }
  }
  onSubmit(): void{


      this.Auth.login(this.checkoutForm.value.email, this.checkoutForm.value.password);

  }

  logout(): void{

    this.Auth.logout();

  }
}

