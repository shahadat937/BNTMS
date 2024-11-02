import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/service/auth.service';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class SharedServiceService {

  constructor(private router: Router,
    private authService: AuthService,
    private location: Location
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

  validateNumberInput(event: KeyboardEvent): void {
    const allowedKeys = ['Backspace', 'Tab', 'ArrowLeft', 'ArrowRight', 'Delete'];
  
    // Allow only number keys and specified control keys
    if (!/^[0-9]$/.test(event.key) && !allowedKeys.includes(event.key)) {
      event.preventDefault(); // Prevent non-numeric characters
    }
  }
  
  filterInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    
    // Remove any non-digit characters from the input
    input.value = input.value.replace(/[^0-9]/g, '');
  }

  validateNumberInputWithDot(event: KeyboardEvent): void {
    const allowedKeys = ['Backspace', 'Tab', 'ArrowLeft', 'ArrowRight', 'Delete', '.'];    
    if (!/^[0-9]$/.test(event.key) && event.key !== '.' && !allowedKeys.includes(event.key)) {
      event.preventDefault(); 
    }
  
    const input = event.target as HTMLInputElement;
  
    if (event.key === '.' && input.value.includes('.')) {
      event.preventDefault(); // Prevent another dot if one is already present
    }
  }

  filterInputWithDot(event: Event): void {
    const input = event.target as HTMLInputElement;
    
    input.value = input.value.replace(/[^0-9.]/g, '');
  
    const parts = input.value.split('.');
    if (parts.length > 2) {
      input.value = parts[0] + '.' + parts.slice(1).join(''); 
    }
  }

  goBack() {
    this.location.back();
  }
  
  

}
