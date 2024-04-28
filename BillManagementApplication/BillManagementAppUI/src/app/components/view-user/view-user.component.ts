import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { BillService } from 'src/app/shared/bill.service';


@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.css']
})
export class ViewUserComponent implements OnInit {
  userData:any;
  id: string= '';
  userSixMonthBillDetail:any;
  constructor(private authService:AuthService, private billService: BillService, private route:ActivatedRoute){}
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.id= params['userId'];
    })
    this.authService.getUserData(this.id)
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.userData= res;
        this.getUserSixMonthBill(this.userData.id)
      }
    })
  }

  getUserSixMonthBill(id:string){
    this.billService.getUserSixMonthBill(id)
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
}
