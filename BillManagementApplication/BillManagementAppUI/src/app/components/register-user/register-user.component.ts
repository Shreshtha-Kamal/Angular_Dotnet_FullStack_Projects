import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { CreatedUserModel } from 'src/app/models/userModel';
import { AuthService } from 'src/app/shared/auth.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  isUserSelectedAsUserType:boolean= true;
  selectedUserType: string='User';
  createdUserDetail:CreatedUserModel={userName: '', name: '',email: '', phoneNumber: '', alternatePhoneNumber:'', address:'', pincode:'', createdAt: new Date('01-01-0001'), password: ''}
  createdAdminDetail:CreatedUserModel={userName: '', name: '',email: '', phoneNumber: '', alternatePhoneNumber:'', address:'', pincode:'', createdAt: new Date('01-01-0001'), password: ''}
  constructor(private authService: AuthService, private router: Router){}

  userTypeControl = new FormControl('',[Validators.required]);
  createUserForm= new FormGroup({
    userName: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required, Validators.min(1)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [Validators.required]),
    alternatePhoneNumber: new FormControl('', [Validators.required]),
    loadAllowed: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    pincode: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  })

  createAdminForm= new FormGroup({
    userName: new FormControl('', [Validators.required]),
    name: new FormControl('', [Validators.required, Validators.min(1)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    phoneNumber: new FormControl('', [Validators.required]),
    alternatePhoneNumber: new FormControl('', [Validators.required]),
    address: new FormControl('', [Validators.required]),
    pincode: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  })

  createUser(){
    this.createdUserDetail.userName= this.createUserForm.value.userName!.toString();
    this.createdUserDetail.name= this.createUserForm.value.name!.toString();
    this.createdUserDetail.email= this.createUserForm.value.email!.toString();
    this.createdUserDetail.phoneNumber= this.createUserForm.value.phoneNumber!.toString();
    this.createdUserDetail.alternatePhoneNumber=this.createUserForm.value.alternatePhoneNumber!.toString();
    this.createdUserDetail.address= this.createUserForm.value.address!.toString();
    this.createdUserDetail.pincode= this.createUserForm.value.pincode!.toString();
    this.createdUserDetail.role= "User";
    this.createdUserDetail.loadAllowed= parseInt(this.createUserForm.value.loadAllowed!.toString());
    var todaysDate= new Date();
    todaysDate.setHours(0,0,0,0);
    this.createdUserDetail.createdAt= todaysDate;
    this.createdUserDetail.password= this.createUserForm.value.password!.toString();
    console.log(this.createdUserDetail);
    this.authService.createUser(this.createdUserDetail)
    .subscribe({
      next:(res)=>{
        alert("User Created Successfully");
        this.createUserForm.reset();
        this.router.navigate(['/adminDashboard']);
      },
      error: (err)=>{
        console.log(err);
        
      }
    })
    
  }

  createAdmin(){
    this.createdAdminDetail.userName= this.createAdminForm.value.userName!.toString();
    this.createdAdminDetail.name= this.createAdminForm.value.name!.toString();
    this.createdAdminDetail.email= this.createAdminForm.value.email!.toString();
    this.createdAdminDetail.phoneNumber= this.createAdminForm.value.phoneNumber!.toString();
    this.createdAdminDetail.alternatePhoneNumber=this.createAdminForm.value.alternatePhoneNumber!.toString();
    this.createdAdminDetail.address= this.createAdminForm.value.address!.toString();
    this.createdAdminDetail.role= "Admin";
    this.createdAdminDetail.pincode= this.createAdminForm.value.pincode!.toString();
    var todaysDate= new Date();
    todaysDate.setHours(0,0,0,0);
    this.createdAdminDetail.createdAt= todaysDate;
    this.createdAdminDetail.password= this.createAdminForm.value.password!.toString();
    console.log(this.createdAdminDetail);
    this.authService.createUser(this.createdAdminDetail)
    .subscribe({
      next:(res)=>{
        alert("Admin User Created Successfully");
        this.createUserForm.reset();
        this.router.navigate(['/adminDashboard']);
      },
      error: (err)=>{
        console.log(err);
      }
    })
    
  }



  ngOnInit(): void {
  }

  onUserTypeChange() {
    if(this.selectedUserType=='User'){
      this.isUserSelectedAsUserType= true;
    }
    if(this.selectedUserType=='Admin'){
      this.isUserSelectedAsUserType= false;
    }
    // This method will be called whenever the selected option changes
    console.log('Selected User Type:', this.selectedUserType);
    console.log(this.isUserSelectedAsUserType);
    
    // You can perform any action here based on the selected user type
  }


  get userName(){
    return this.createUserForm.get('userName');
  }
  get name(){
    return this.createUserForm.get('name');
  }
  get email(){
    return this.createUserForm.get('email');
  }
  get phoneNumber(){
    return this.createUserForm.get('phoneNumber');
  }
  get alternatePhoneNumber(){
    return this.createUserForm.get('alternatePhoneNumber');
  }
  get loadAllowed(){
    return this.createUserForm.get('loadAllowed');
  }
  get address(){
    return this.createUserForm.get('address');
  }
  get pincode(){
    return this.createUserForm.get('pincode');
  }
  get password(){
    return this.createUserForm.get('password');
  }
  
}
