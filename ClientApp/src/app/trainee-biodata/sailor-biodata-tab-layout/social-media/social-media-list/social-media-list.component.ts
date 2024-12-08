import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SocialMedia } from '../../models/SocialMedia';
import { SocialMediaService } from '../../service/SocialMedia.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import { MasterData } from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-social-media-list',
  templateUrl: './social-media-list.component.html',
  styleUrls: ['./social-media-list.component.sass']
})
export class SocialMediaListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: SocialMedia[] = [];
  isLoading = false;
  traineeId: string;
  role: string;
  userRoles = Role;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = ['ser', 'socialMediaTypeName', 'socialMediaAccountName', 'actions'];
  dataSource: MatTableDataSource<SocialMedia> = new MatTableDataSource();

  SelectionModel = new SelectionModel<SocialMedia>(true, []);

  constructor(private route: ActivatedRoute, private snackBar: MatSnackBar, private SocialMediaService: SocialMediaService, private router: Router, private confirmService: ConfirmService, private authService: AuthService, private sharedService: SharedServiceService) {
    super();
  }
  ngOnInit() {
    this.role = this.authService.currentUserValue.role;
    this.getSocialMedias();
  }

  getSocialMedias() {
    this.isLoading = true;
    // if user is trinee trineeId will populated from authService
    this.traineeId = this.route.snapshot.paramMap.get('traineeId') || this.authService.currentUserValue.traineeId;

    this.checkTraineeId(this.traineeId);
    this.SocialMediaService.getSocialMediaByTraineeId(+this.traineeId).subscribe(response => {
      this.dataSource.data = response;
    })
  }

  pageChanged(event: PageEvent) {

    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getSocialMedias();

  }
  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getSocialMedias();
  }

  checkTraineeId(traineeId) {
    if (this.role === this.userRoles.Student && traineeId !== this.authService.currentUserValue.traineeId)
      this.sharedService.goBack(); // Navigate back

  }


  deleteItem(row) {
    const id = row.socialMediaId;
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.SocialMediaService.delete(id).subscribe(() => {
          this.getSocialMedias();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
  }

}
