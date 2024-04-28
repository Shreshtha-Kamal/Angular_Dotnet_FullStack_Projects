import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { userAuthGuard } from './guards/user-auth.guard';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { adminAuthGuard } from './guards/admin-auth.guard';
import { CreateBillComponent } from './components/create-bill/create-bill.component';
import { ViewUserComponent } from './components/view-user/view-user.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { ViewBillComponent } from './components/view-bill/view-bill.component';

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'dashboard', component: UserDashboardComponent, canActivate:[userAuthGuard]},
  {path: 'adminDashboard', component: AdminDashboardComponent, canActivate:[adminAuthGuard]},
  {path: 'createBill/:userId', component: CreateBillComponent, canActivate:[adminAuthGuard]},
  {path: 'viewUser/:userId', component: ViewUserComponent, canActivate:[adminAuthGuard]},
  {path: 'registerUser', component: RegisterUserComponent, canActivate: [adminAuthGuard]},
  {path: 'viewBill/:billId', component: ViewBillComponent, canActivate: [userAuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
