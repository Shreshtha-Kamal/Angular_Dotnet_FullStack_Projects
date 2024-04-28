import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginData } from '../models/loginModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = "https://localhost:7119/api/Auth/"
  constructor(private http: HttpClient) { }

  login(loginObj:LoginData){
    return  this.http.post<any>(this.baseUrl + 'login', loginObj);
  }

  getUserRole(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl+'getUserRole', {headers});
  }
}
