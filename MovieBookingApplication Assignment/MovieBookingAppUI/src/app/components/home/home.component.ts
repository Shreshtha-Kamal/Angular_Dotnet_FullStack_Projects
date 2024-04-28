import { Component, OnInit } from '@angular/core';
import {  FormControl, FormGroup, Validators, FormBuilder } from "@angular/forms";
import { MovieShowService } from 'src/app/shared/movie-show.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isResetDisabled:boolean = true;
  availableMovieShows : any = [];
  areMovieShowsAvailable:boolean= true;
  isSearchCriteriaFilled:boolean= false;
  constructor(private showService: MovieShowService){}
  searchFilter = new FormGroup({
    date: new FormControl('', [Validators.required])
  })

  ngOnInit(): void {
    this.getAvailableMovieShows();
  } 
  getAvailableMovieShows(){
    this.showService.getAvailableMovieShows()
    .subscribe({
      next:(res)=>{
        this.availableMovieShows= res
        if(this.availableMovieShows.length==0){
          this.areMovieShowsAvailable= false;
        }
      },
      error:(err)=>{
        alert("Server Error Occured")
        this.areMovieShowsAvailable=false;
      }
    })
  }

  searchFilteredMovieShow(){
    this.showService.getFilteredAvailableMovieShow(new Date(this.searchFilter.value.date!.toString()))
    .subscribe({
      next:(res)=>{
        this.availableMovieShows= res;
        this.isResetDisabled= false;
      }
    })
  }

  resetShowData(){
   this.getAvailableMovieShows();
   this.searchFilter.reset();
   this.isResetDisabled= true; 
  }

  get date(){
    return this.searchFilter.get('date');
  }
}
