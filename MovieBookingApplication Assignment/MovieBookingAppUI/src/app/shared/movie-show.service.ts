import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AddMovieShowModel } from '../models/showModel';

@Injectable({
  providedIn: 'root'
})
export class MovieShowService {
  private baseUrl: string= "https://localhost:7119/api/Show/"
  constructor(private http:HttpClient) { }

  getAvailableMovieShows(){
    return this.http.get<any>(this.baseUrl + 'getAllAvailableShows');
  }

  getFilteredAvailableMovieShow(date:Date){
    const dateString= date.toISOString();
    return this.http.get<any>(this.baseUrl + `getAllFilteredAvailableShows/${dateString}`);
  }

  getMovieShow(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl + `getMovie/${id}`, {headers})
  }

  addShow(showObj:AddMovieShowModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.post<any>(this.baseUrl+ 'addShowForMovie', showObj, {headers});
  }
}
