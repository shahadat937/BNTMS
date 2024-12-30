import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/service/auth.service';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class SharedServiceService {
  groupedData: { 
    groupKey: string;        // Represents the name of the group (e.g., school name) 
    groupedItems: any[];     // Represents the array of items under this group 
  }[];
  
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

  verifyPno(event: KeyboardEvent) {
    const key = event.key;
  
    // Allow alphanumeric characters, underscore, space, comma, and control keys (backspace, delete, arrows)
    const isValid = /^[a-zA-Z0-9_]$/.test(key) || 
                    ['Backspace', 'Delete', 'ArrowLeft', 'ArrowRight'].includes(key);
  
    // If the key is not valid, prevent the default action
    if (!isValid) {
      event.preventDefault();
    }
  }
  


  formatDateTime(date: any): string {

    let validDate: Date = new Date();
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

  groupByTableType(data: any[]): any[] {
    const groupedData = data.reduce((groups, key) => {
      const forceType = key.forceType || 'Unknown';
      if (!groups[forceType]) {
        groups[forceType] = [];
      }
      groups[forceType].push(key);
      return groups;
    }, {});

    return Object.keys(groupedData).map(forceType => ({
      forceType: forceType,
      organization: groupedData[forceType],
    }));
  }

  shouldDisplayRowspan(data: any[], currentElement: any, currentIndex: number): boolean {
    if (currentIndex === 0) return true;
    return data[currentIndex - 1].tableType !== currentElement.tableType;
  }

  getRowspan(data: any[], forceType: string): number {
    return data.filter(item => item.forceType === forceType).length;
  }


  groupBy(arr, keyFn) {
    const groups = {};
    arr.forEach(item => {
      const key = keyFn(item);
      groups[key] = groups[key] || [];
      groups[key].push(item);
    });
     

   return Object.keys(groups).map((groupKey) => {   
      return {groupKey,groupedItems: groups[groupKey]
      };
    });
  }
}
