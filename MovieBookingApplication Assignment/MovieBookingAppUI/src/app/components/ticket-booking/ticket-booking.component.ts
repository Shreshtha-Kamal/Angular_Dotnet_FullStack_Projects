import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TicketModel } from 'src/app/models/ticketModel';
import { MovieShowService } from 'src/app/shared/movie-show.service';
import { MovieService } from 'src/app/shared/movie.service';
import { TicketService } from 'src/app/shared/ticket.service';


function maxTicketsValidator(availableSeats: number): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const bookedTickets = control.value;
    const maxTickets = availableSeats < 10 ? availableSeats : 10;
    
    if (bookedTickets > maxTickets) {
      return { maxTicketsExceeded: true };
    }
    
    return null;
  };
}

@Component({
  selector: 'app-ticket-booking',
  templateUrl: './ticket-booking.component.html',
  styleUrls: ['./ticket-booking.component.css']
})

export class TicketBookingComponent implements OnInit {

  seatRemaining: number= 0;
  maxSeatsAllowed:number=10;
  movieShowId:string= '';
  bookingDate:Date= new Date();
  movieWithShowDetails: any;
  ticketData: TicketModel= {SeatCount: 1, ShowDate: new Date(), ShowId: '' }
  constructor(private route: ActivatedRoute, private router : Router, private movieService:MovieService, private ticketService: TicketService){}
  seatCountForm= new FormGroup({
    seatNumber: new FormControl(1, [Validators.required, Validators.min(1), Validators.max(this.maxSeatsAllowed)])
  })
  ngOnInit(): void {
    this.route.params.subscribe(param=>{
      this.seatRemaining= param['seatAvailable'],
      this.movieShowId= param['movieId'],
      this.bookingDate= param['bookingDate']
    })
    this.movieService.getMovieWithShow(this.movieShowId)
    .subscribe({
      next:(res)=>{
        console.log(res);
        
        this.movieWithShowDetails= res;
        this.maxSeatsAllowed= this.seatRemaining<10? this.seatRemaining: 10;
      },
      error:(err)=> {
        console.log(err);
      }
    })
  }
  bookTicket(){
    this.ticketData.SeatCount= parseInt(this.seatCountForm.value.seatNumber!.toString());
    this.ticketData.ShowId= this.movieWithShowDetails.movieShow.showId;
    this.ticketData.ShowDate= this.bookingDate;
    console.log(this.ticketData);
    
    this.ticketService.createTicket(this.ticketData)
    .subscribe({
      next:(res)=>{
        alert(`Your Ticket has been Booked Successfully \n Your Ticket Id is: ${res.ticketId}`);
        this.seatCountForm.reset();
        this.router.navigate(['/dashboard']);
      },
      error:(err)=>{
        console.log(err);
        
      }
    })
    
  }

  get seatNumber(){
    return this.seatCountForm.get('seatNumber');
  }
}
