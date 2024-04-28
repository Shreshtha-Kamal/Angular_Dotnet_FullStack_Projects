import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, ValidationErrors } from "@angular/forms";
import { ActivatedRoute, Router } from '@angular/router';
import { Bill } from 'src/app/models/billModel';
import { AuthService } from 'src/app/shared/auth.service';
import { BillService } from 'src/app/shared/bill.service';

@Component({
  selector: 'app-create-bill',
  templateUrl: './create-bill.component.html',
  styleUrls: ['./create-bill.component.css']
})
export class CreateBillComponent implements OnInit {
  id: string ='';
  userData:any={};
  createdBillDetails:Bill={userId: '', unitsConsumed:1, perUnitPrice:1, startDate:new Date('01-01-0001'), endDate: new Date('01-01-0001'), dueDate: new Date('01-01-0001'), lateCharge:1, loadAllowed:2 };
  constructor(private authService: AuthService, private billService: BillService, private route: ActivatedRoute, private router:Router){}

  createBillForm= new FormGroup({
    userId: new FormControl(this.id, [Validators.required]),
    unitsConsumed: new FormControl('', [Validators.required, Validators.min(1)]),
    unitPrice: new FormControl('', [Validators.required, Validators.min(1)]),
    allowedLoad: new FormControl(this.userData.loadAllowed, [Validators.required]),
    startDate: new FormControl('', [Validators.required]),
    endDate: new FormControl('', [Validators.required]),
    dueDate: new FormControl('', [Validators.required]),
    lateCharge: new FormControl('', [Validators.required])
  })
  ngOnInit(): void {
    this.route.params.subscribe(params=>{
      this.id=params['userId'];
      this.createBillForm.get('userId')!.setValue(this.id);
    })
    this.authService.getUserData(this.id)
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.userData= res;
        this.createBillForm.get('allowedLoad')!.setValue(this.userData.loadAllowed);
      }
    })
  }

  // endDateValidator(control:AbstractControl): ValidationErrors|null {
  //   const startDate = this.createBillForm.get('startDate')?.value;
  //   const endDate = control.value;
  //   return startDate && endDate && endDate > startDate ? null : { endDateInvalid: true };
  // }

  createBill(){
    this.createdBillDetails.userId = this.createBillForm.value.userId!.toString();
    this.createdBillDetails.unitsConsumed= parseInt(this.createBillForm.value.unitsConsumed!.toString());
    this.createdBillDetails.perUnitPrice= parseInt(this.createBillForm.value.unitPrice!.toString());
    this.createdBillDetails.startDate= new Date(this.createBillForm.value.startDate!.toString());
    this.createdBillDetails.endDate= new Date(this.createBillForm.value.endDate!.toString());
    this.createdBillDetails.dueDate= new Date(this.createBillForm.value.dueDate!.toString());
    this.createdBillDetails.lateCharge= parseInt(this.createBillForm.value.lateCharge!.toString());
    this.createdBillDetails.loadAllowed= parseInt(this.createBillForm.value.allowedLoad!.toString());
    console.log(this.createdBillDetails);
    this.billService.createBill(this.createdBillDetails)
    .subscribe({
      next:(res)=>{
        alert("Bill Created Successfully for the User");
        this.createBillForm.reset();
        this.router.navigate(['/adminDashboard']);
      },
      error:(err)=>{
        console.log(err);
      }
    })
    
  }
  get userId(){
    return this.createBillForm.get('userId');
  }
  get unitsConsumed(){
    return this.createBillForm.get('unitsConsumed');
  }
  get unitPrice(){
    return this.createBillForm.get('unitPrice');
  }
  get allowedLoad(){
    return this.createBillForm.get('allowedLoad');
  }
  get startDate(){
    return this.createBillForm.get('startDate');
  }
  get endDate(){
    return this.createBillForm.get('endDate');
  }
  get dueDate(){
    return this.createBillForm.get('dueDate');
  }
  get lateCharge(){
    return this.createBillForm.get('lateCharge');
  }
  
}
