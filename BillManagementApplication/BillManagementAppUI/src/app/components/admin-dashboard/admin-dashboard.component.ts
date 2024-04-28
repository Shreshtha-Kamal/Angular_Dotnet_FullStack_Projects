import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { AuthService } from 'src/app/shared/auth.service';
import { UserAndRecentBillData } from 'src/app/models/userAndBillDataModel';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';


@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, MatSortModule, MatButtonModule, MatPaginatorModule],
})
export class AdminDashboardComponent implements AfterViewInit, OnInit{
  displayedColumns: string[] = ['userId', 'name', 'pincode','latestBillAmount', 'billStatus', 'action'];
  dataSource: MatTableDataSource<UserAndRecentBillData>;
  userDetails!: UserAndRecentBillData[];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort
  constructor(private authService: AuthService, private router: Router) {
    // Assign the data to the data source for the table to render
    this.dataSource = new MatTableDataSource<UserAndRecentBillData>(this.userDetails);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.authService.getUserDataWithRecentBillDetail()
    .subscribe({
      next:(res)=>{
        console.log(res);
        this.userDetails= res;
        this.dataSource = new MatTableDataSource<UserAndRecentBillData>(this.userDetails);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  createBill(id:string){
    this.router.navigate(['/createBill',id]);
  }
  viewUser(id:string){
    this.router.navigate(['/viewUser', id]);
  }
}
