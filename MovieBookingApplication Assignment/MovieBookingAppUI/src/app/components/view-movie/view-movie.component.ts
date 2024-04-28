import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/shared/movie.service';

@Component({
  selector: 'app-view-movie',
  templateUrl: './view-movie.component.html',
  styleUrls: ['./view-movie.component.css']
})
export class ViewMovieComponent implements OnInit{
  movieId:string='';
  movieWithShowDetails:any;
  constructor(private route:ActivatedRoute, private movieService:MovieService){}
  ngOnInit(): void {
    this.route.params.subscribe(param=>{
      this.movieId = param['movieId'];
    })
    this.movieService.getMovieWithShow(this.movieId)
    .subscribe({
      next:(res)=>{
        this.movieWithShowDetails= res;
      }, 
      error:(err)=>{
        alert('Internal Server Error Unable to Fetch Movie Detail');
        console.log(err);
        
      }
    })
  }
}
