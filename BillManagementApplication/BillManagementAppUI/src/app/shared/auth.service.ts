import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { LoginUser } from '../models/loginModel';
import { UserAndRecentBillData } from '../models/userAndBillDataModel';
import { CreatedUserModel } from '../models/userModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl:string= "https://localhost:7254/api/Auth/"
  constructor(private http:HttpClient) { }

  
  login(loginObj:LoginUser){
    return this.http.post<any>(this.baseUrl+'login', loginObj);
  }

  getUserRole(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl+'getUserRole', {headers});
  }

  getUserIdThroughToken(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl+'getAuthUserId', {headers});
  }

  getUserData(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl+`getUserbyId/${id}`, {headers});
  }

  getUserDataWithRecentBillDetail(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<Array<UserAndRecentBillData>>(this.baseUrl + 'getAllUsersWithBillDetail', {headers})
  }

  createUser(userData:CreatedUserModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.post<any>(this.baseUrl + 'registerUser', userData, {headers});
  }
}
