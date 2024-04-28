import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { userAuthGuard } from './guards/user-auth.guard';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { adminAuthGuard } from './guards/admin-auth.guard';
import { TicketBookingComponent } from './components/ticket-booking/ticket-booking.component';
import { AddMovieComponent } from './components/add-movie/add-movie.component';
import { AddShowComponent } from './components/add-show/add-show.component';
import { ViewMovieComponent } from './components/view-movie/view-movie.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'dashboard', component: DashboardComponent, canActivate:[userAuthGuard]},
  {path: 'adminDashboard', component: AdminDashboardComponent, canActivate:[adminAuthGuard]},
  {path: 'ticketBooking/:movieId/:seatAvailable', component: TicketBookingComponent, canActivate:[userAuthGuard]},
  {path: 'ticketBooking/:movieId/:seatAvailable/:bookingDate', component: TicketBookingComponent, canActivate:[userAuthGuard]},
  {path: 'addMovie', component: AddMovieComponent, canActivate: [adminAuthGuard]},
  {path: 'addShow/:movieId', component: AddShowComponent, canActivate: [adminAuthGuard]},
  {path: 'viewMovie/:movieId', component:ViewMovieComponent, canActivate:[adminAuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
