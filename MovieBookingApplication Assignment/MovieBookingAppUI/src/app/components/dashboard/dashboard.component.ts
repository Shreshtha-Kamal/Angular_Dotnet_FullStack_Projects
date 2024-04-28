import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MovieShowService } from 'src/app/shared/movie-show.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

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

  redirectToTicketBookingScreen(movieId:string, seatRemaining:string, searchedDate ?: string){
    if(this.isResetDisabled){
      var currentDate= new Date();
      var todaysDate= currentDate.toISOString().split('T')[0];
      return `/ticketBooking/${movieId}/${seatRemaining}/${todaysDate.toString()}`
    }
    return `/ticketBooking/${movieId}/${seatRemaining}/${this.searchFilter.value.date!.toString()}`
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
