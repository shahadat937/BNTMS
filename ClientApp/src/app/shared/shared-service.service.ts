import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/service/auth.service';

@Injectable({
  providedIn: 'root'
})
export class SharedServiceService {

  constructor(private router: Router,
    private authService: AuthService,
  ) { }

  redirectDashboard(){
    const role = this.authService.currentUserValue.role.trim();
    const traineeId =  this.authService.currentUserValue.traineeId.trim();
    if(traineeId != null && traineeId != "") {
      if(role == "Instructor"){
        return '/admin/dashboard/instructor-dashboard';
      }
      else {
        return '/admin/dashboard/trainee-dashboard';
      }
    }
    else {
      if(role == "Master Admin"){
        return '/admin/dashboard/main';
      }
      else {
        return '/admin/dashboard/school-dashboard';
      }
    }
  }
}
