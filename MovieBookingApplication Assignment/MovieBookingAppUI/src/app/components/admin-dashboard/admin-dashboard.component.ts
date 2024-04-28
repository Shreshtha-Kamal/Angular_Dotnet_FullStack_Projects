import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/shared/movie.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit{
  allMovies:any;
  areMoviesAvailable:boolean= true;
  constructor(private movieService: MovieService){}

  ngOnInit(): void {
    this.movieService.getAllMovies()
    .subscribe({
      next: (res)=>{
        this.allMovies= res;
        if(this.allMovies.length==0){
          this.areMoviesAvailable= false;
        }
      },
      error:(err)=>{
        this.areMoviesAvailable= false;
        alert(err.value.message)
      }
    })
  }
}
