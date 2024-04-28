import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MovieModel } from '../models/movieModel';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  private baseUrl: string= "https://localhost:7119/api/Movie/"
  constructor(private http:HttpClient) { }

  getMovieWithShow(id:string){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl + `getMovie/${id}`, {headers})
  }

  getAllMovies(){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.get<any>(this.baseUrl + 'getAllMovies', {headers});
  }

  addMovie(movieObj: MovieModel){
    var token= localStorage.getItem('authToken');
    const headers= new HttpHeaders({
      'Content-Type':'application/json',
      'Authorization' : `Bearer ${token}`
    })
    return this.http.post<any>(this.baseUrl + 'AddMovie', movieObj, {headers});
  }
}
