import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TicketModel } from '../models/ticketModel';

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  baseUrl:string = "https://localhost:7119/api/Ticket/";
  constructor(private http : HttpClient) { }

  createTicket(ticketData: TicketModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.post<any>(this.baseUrl + 'generateTicket', ticketData, {headers});
  }
}
