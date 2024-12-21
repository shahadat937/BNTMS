import { Component, Input, OnInit } from '@angular/core';
import { GlobalSearchService } from '../../services/global-search.service';
import { nextSortDir } from '@swimlane/ngx-datatable';
import { UserService } from 'src/app/security/service/User.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-searched-trainee-detail',
  templateUrl: './searched-trainee-detail.component.html',
  styleUrls: ['./searched-trainee-detail.component.sass']
})
export class SearchedTraineeDetailComponent implements OnInit {
  @Input() Payload: any;
  columnNames = ["Course", "Action"]
  traineeDetails :any ;
  loading: boolean;
  subscription: Subscription = new Subscription();

  constructor(
    private globalSearchService: GlobalSearchService,
    private userService: UserService,
    private snackbar: MatSnackBar,
    private confirmService: ConfirmService
  ) { 
    this.Payload = null; 
    this.traineeDetails = null;
    this.loading = false;
  }

  ngOnInit(): void {
    if(this.Payload!=null&&this.Payload.Type=='Trainee') {
      this.getTraineeDetail();
    } else if(this.Payload!=null&&this.Payload.Type=='Instructor') {
      this.getInstructorDetail();
    }
  }

  getTraineeDetail() {
    this.loading = true;
    this.globalSearchService.getTraineeDetail(this.Payload.TraineeId).subscribe({
      next: response => {
        this.traineeDetails = response;
      },
      error: err => {
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    })
  }

  getInstructorDetail() {
    this.loading = true;
    this.globalSearchService.getInstructorDetail(this.Payload.TraineeId).subscribe({
      next: response => {
        this.traineeDetails = response;
      },
      error: err => {
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    })
  }


  PasswordUpdate(userId) {
    const id = userId;
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Resetting This  User Password?').subscribe(result => {


      if (id&&result) {
        this.subscription = this.userService.find(id).subscribe(

          res => {
            let userData ={          
  
              id: res.id,
              userName: res.userName,            
              roleName: res.roleName,         
              firstName : res.firstName,
              lastName : res.lastName,
              phoneNumber : res.phoneNumber,
              email : res.email,   
              traineeId:res.traineeId,
              password: 'demo',
              confirmPassword: 'demo'
            
            };
            this.subscription = this.userService.resetPassword(id,userData).subscribe(response => {
              // this.router.navigateByUrl('/security/instructor-list');
              //vaiya eta theke ami password nicchi
              //this.getInstructors();
              this.snackbar.open('Password Reset Successful', '', {
                duration: 2000,
                verticalPosition: 'bottom',
                horizontalPosition: 'right',
                panelClass: 'snackbar-success'
              });
            })
            
          }
        );        
      }
    })
    
  }

  getCourseStatus(data:any) {

    const from = new Date(data.durationFrom);
    const to = new Date(data.durationTo);
    const curDate = new Date();
    if(curDate>=from&&curDate<=to) {
      return 0; // running course
    } else if(to<curDate) {
      return -1; // previous course
    } else {
      return 1; // upcoming course
    }
  }

}
