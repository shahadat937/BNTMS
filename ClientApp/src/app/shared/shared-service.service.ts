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

  redirectDashboard() {
    const role = this.authService.currentUserValue.role.trim();
    const traineeId = this.authService.currentUserValue.traineeId.trim();
    if (traineeId != null && traineeId != "") {
      if (role == "Instructor") {
        return '/admin/dashboard/instructor-dashboard';
      }
      else {
        return '/admin/dashboard/trainee-dashboard';
      }
    }
    else {
      if (role == "Master Admin") {
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

  formatDateTime(date: any): string {

    let validDate: Date;
    if (date instanceof Date) {
      validDate = date;
    } 
    else if (typeof date === 'string') {

      validDate = new Date(date);

      if (isNaN(validDate.getTime())) {
        validDate = new Date(date.replace('T', ' '));
      }
    } 

    // Format the date components
    const year = validDate.getFullYear();
    const month = (validDate.getMonth() + 1).toString().padStart(2, '0'); //  2-digit month
    const day = validDate.getDate().toString().padStart(2, '0');           //  2-digit day
    const hours = validDate.getHours().toString().padStart(2, '0');        //  2-digit hours
    const minutes = validDate.getMinutes().toString().padStart(2, '0');    //  2-digit minutes
    const seconds = validDate.getSeconds().toString().padStart(2, '0');    //  2-digit seconds

    // Return the formatted date string
    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
  }




}
