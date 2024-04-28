import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { BillService } from 'src/app/shared/bill.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent {
  userData:any;
  id: string= '';
  userSixMonthBillDetail:any;
  constructor(private authService:AuthService, private billService: BillService, private route:ActivatedRoute){}
  ngOnInit(): void {
    this.authService.getUserIdThroughToken()
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.id= res.userId;
        this.getUserData();
      }
    })
  }

  getUserData(){
    this.authService.getUserData(this.id)
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.userData= res;
        this.getUserSixMonthBill()
      }
    })
  }

  getUserSixMonthBill(){
    this.billService.getUserSixMonthBill(this.id)
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.userSixMonthBillDetail= res;
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }

  payBill(billId:string){
    this.billService.payBill(billId)
    .subscribe({
      next:(res)=>{
        console.log(res);
        alert("Bill Paid SuccessFully")
        this.getUserSixMonthBill()
      },
      error:(err)=>{
        console.log(err);
        
      }
    })
  }
}
