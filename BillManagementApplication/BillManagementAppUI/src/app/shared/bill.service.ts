import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Bill } from '../models/billModel';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  private baseUrl:string= "https://localhost:7254/api/Bill/"
  constructor(private http:HttpClient) { }

  createBill(billData:Bill){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.post<any>(this.baseUrl + 'createBill', billData, {headers});
  }

  getUserSixMonthBill(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl +`getUserSixMonthsBills/${id}`, {headers});
  }

  getBillById(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
  }

  payBill(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.post<any>(this.baseUrl + `payBill/${id}`, null, {headers});
  }
}
