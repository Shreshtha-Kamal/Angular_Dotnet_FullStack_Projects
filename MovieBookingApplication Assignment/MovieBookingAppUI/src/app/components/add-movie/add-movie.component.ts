import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { MovieModel } from 'src/app/models/movieModel';
import { MovieService } from 'src/app/shared/movie.service';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.css']
})
export class AddMovieComponent {
  responseMovieObjFromBackend: any;
  constructor(private movieService: MovieService, private router: Router){}
  addedMovieDetails: MovieModel= {Name: '', Genre: '', DirectorName: '', Description: '', BannerImageUrl: '', MovieLengthInMinutes: 1};
  addMovieForm= new FormGroup({
    movieName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    genre: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(15)]),
    director: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]),
    description: new FormControl('', [Validators.required, Validators.maxLength(150)]),
    bannerImageLink: new FormControl('', [Validators.required, Validators.pattern(/^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$/)]),
    movieLength: new FormControl(1, [Validators.required, Validators.min(1)])
  })

  addMovie(){
    this.addedMovieDetails.Name=this.addMovieForm.value.movieName!.toString();
    this.addedMovieDetails.Genre= this.addMovieForm.value.genre!.toString();
    this.addedMovieDetails.DirectorName= this.addMovieForm.value.director!.toString();
    this.addedMovieDetails.Description= this.addMovieForm.value.description!.toString();
    this.addedMovieDetails.BannerImageUrl= this.addMovieForm.value.bannerImageLink!.toString();
    this.addedMovieDetails.MovieLengthInMinutes= parseInt(this.addMovieForm.value.movieLength!.toString());
    console.log(this.addedMovieDetails);
    this.movieService.addMovie(this.addedMovieDetails)
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.responseMovieObjFromBackend= res;
        this.addMovieForm.reset();
        alert('Movie Added Successfully');
        this.router.navigate(['/addShow', this.responseMovieObjFromBackend.movieId]);
      },
      error:(err)=>{
        console.log(err);
        alert('Server Error Occured 404');
      }
    })
    
  }

  get movieName(){
    return this.addMovieForm.get('movieName');
  }

  get genre(){
    return this.addMovieForm.get('genre');
  }

  get director(){
    return this.addMovieForm.get('director');
  }

  get description(){
    return this.addMovieForm.get('description');
  }

  get bannerImageLink(){
    return this.addMovieForm.get('bannerImageLink');
  }

  get movieLength(){
    return this.addMovieForm.get('movieLength');
  }

}
