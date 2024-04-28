import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { AddMovieShowModel } from 'src/app/models/showModel';
import { MovieShowService } from 'src/app/shared/movie-show.service';

@Component({
  selector: 'app-add-show',
  templateUrl: './add-show.component.html',
  styleUrls: ['./add-show.component.css']
})
export class AddShowComponent implements OnInit {
  movieIdFromRoute:string= '';
  showDetails:AddMovieShowModel= {StartDate: new Date('01-01-0001'), EndDate: new Date('01-01-0001'), StartTime:'', EndTime: '',TotalSeats: 10, Price:1,ScreenId:1,MovieId:''};
  constructor(private route: ActivatedRoute, private showService: MovieShowService, private router: Router){  }

  addShowForm= new FormGroup({
    startDate: new FormControl('', [Validators.required]),
    endDate: new FormControl('', [Validators.required]),
    startTime: new FormControl('', [Validators.required]),
    endTime: new FormControl('', [Validators.required]),
    totalSeats: new FormControl('', [Validators.required,Validators.min(10), Validators.max(400)]),
    price: new FormControl('',[Validators.required,Validators.min(100), Validators.max(1000)]),
    screenNumber: new FormControl(1, [Validators.required, Validators.min(1), Validators.max(4)])
  })
  ngOnInit(): void {
    this.route.params
    .subscribe(param=>{
      this.movieIdFromRoute= param['movieId'];
    })
  }


  addShow(){
    this.showDetails.StartDate= new Date(this.addShowForm.value.startDate!.toString());
    this.showDetails.EndDate= new Date(this.addShowForm.value.endDate!.toString());
    this.showDetails.StartTime= this.addShowForm.value.startTime!.toString()+':00';
    this.showDetails.EndTime= this.addShowForm.value.endTime!.toString()+':00';
    this.showDetails.TotalSeats= parseInt(this.addShowForm.value.totalSeats!.toString());
    this.showDetails.Price= parseInt(this.addShowForm.value.price!.toString());
    this.showDetails.ScreenId= parseInt(this.addShowForm.value.screenNumber!.toString());
    this.showDetails.MovieId= this.movieIdFromRoute;
    console.log(this.showDetails);
    this.showService.addShow(this.showDetails)
    .subscribe({
      next:(res)=>{
        alert('Show Added SuccessFully');
        this.addShowForm.reset();
        this.router.navigate(['/adminDashboard']);
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }
  get startDate(){
    return this.addShowForm.get('startDate');
  }

  get endDate(){
    return this.addShowForm.get('endDate');
  }

  get startTime(){
    return this.addShowForm.get('startTime');
  }
  get endTime(){
    return this.addShowForm.get('endTime');
  }

  get totalSeats(){
    return this.addShowForm.get('totalSeats');
  }
  get price(){
    return this.addShowForm.get('price');
  }
  get screenNumber(){
    return this.addShowForm.get('screenNumber');
  }
}
