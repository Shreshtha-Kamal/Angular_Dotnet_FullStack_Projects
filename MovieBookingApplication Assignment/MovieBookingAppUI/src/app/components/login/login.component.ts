import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginData } from 'src/app/models/loginModel';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private authService: AuthService, private route: Router){}
  loginData:LoginData= {UserName: '', Password: ''}
  loginForm= new FormGroup({
    userName: new FormControl('', [ Validators.required,  Validators.pattern(/^\S{6,}$/)]),
    password: new FormControl('', [ Validators.required, Validators.minLength(6)])
  })

  loginUser(){
    this.loginData.UserName= this.loginForm.value.userName!.toString();
    this.loginData.Password= this.loginForm.value.password!.toString();
    this.authService.login(this.loginData)
    .subscribe({
      next:(res)=>{
        alert("Login Success:200")
        localStorage.setItem('authToken', res.token);
        this.getUserRole();
        this.loginForm.reset();
      },
      error:(errorResponse)=>{
        alert("Invalid Credential")
        console.log(errorResponse);
      }
    })
  }

  getUserRole(){
    this.authService.getUserRole()
    .subscribe({
      next:(res)=>{
        localStorage.setItem('loggedInUserType',res.userRole);
        if(res.userRole=='Admin'){
          localStorage.setItem('isAdminLoggedin', 'true');
          this.route.navigate(['/adminDashboard']);
        }
        if(res.userRole=='User'){
          localStorage.setItem('isUserLoggedIn', 'true');
          this.route.navigate(['/dashboard']);
        }
      },
      error:(err)=>{
        console.error(err);
      }
    })
    
  }

  get userName(){
    return this.loginForm.get('userName');
  }

  get password(){
    return this.loginForm.get('password');
  }
}
