import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {ChildParameterService} from '../service/ChildParameter.service'
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { Role } from '../../../../../src/app/core/models/role';

@Component({
  selector: 'app-main-tab-layout',
  templateUrl: './main-tab-layout.component.html',
  styleUrls: ['./main-tab-layout.component.sass']
})
export class MainTabLayoutComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  
  
  title = 'angular-material-tab-router';  
  navLinks: any[];
  id: any;
  activeLinkIndex = -1; 
  role : string;
  userRoles = Role;
  constructor(private router: Router, private route: ActivatedRoute, private childParameterService: ChildParameterService, public sharedService: SharedServiceService, private authService : AuthService) {
    
    super();
    this.navLinks = [
      {
        label: 'General Information',
        link: '/trainee-biodata/sailor-biodata-tab/main-tab-layout/main-tab/update-traineebiodatageneralinfo',
        index: 0
      },
      {
        label: 'Educational Qualification',
        link: '/trainee-biodata/sailor-biodata-tab/main-tab-layout/main-tab/educational-qualification-details',
        index: 1
      },
      {
        label: 'Game and Sports',
        link: '/trainee-biodata/sailor-biodata-tab/main-tab-layout/main-tab/game-sport-details',
        index: 2
      },
      {
        label: 'Family Info',
        link: '/trainee-biodata/sailor-biodata-tab/main-tab-layout/main-tab/family-info-details',
        index: 3
      },
      {
        label: 'Social Media',
        link: '/trainee-biodata/sailor-biodata-tab/main-tab-layout/main-tab/social-media-details',
        index: 4
      },
    ];
    
    
    
  }
  ngOnInit(): void {
   this.role = this.authService.currentUserValue.role;
    this.id = this.route.snapshot.paramMap.get('traineeId');
    //this.id = 17;
    if (this.id) {
      this.childParameterService.SetupTraineeId(this.id);
    }
    else{
      if (this.childParameterService.currentTraineeValue) {
        this.id = this.childParameterService.currentTraineeValue;
      }
    }
  
    
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });
  }


}
