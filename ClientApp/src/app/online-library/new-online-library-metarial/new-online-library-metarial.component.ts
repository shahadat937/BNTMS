import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Role } from 'src/app/core/models/role';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { OnlineLibraryMaterial } from '../models/onlinelibrarymaterial';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { InstructorDashboardService } from 'src/app/teacher/services/InstructorDashboard.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { OnlinelibraryService } from '../service/onlinelibrary.service';
import { FileDialogMessageComponent } from 'src/app/reading-materials/readingmaterial/file-dialog-message/file-dialog-message.component';
import { HttpEvent, HttpEventType } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-new-online-library-metarial',
  templateUrl: './new-online-library-metarial.component.html',
  styleUrls: ['./new-online-library-metarial.component.sass']
})
export class NewOnlineLibraryMetarialComponent implements OnInit {

  masterData = MasterData;
  loading = false;
  roleList = Role;
  buttonText: string;
  pageTitle: string;
  destination: string;
  onlineLibraryForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse: SelectedModel[];
  selectedschool: SelectedModel[];
  selecteddocs: SelectedModel[];
  selectDocument: SelectedModel[];
  selectedLocationType: SelectedModel[];
  selecteddownload: SelectedModel[];
  selectedReadingMaterialTitle: SelectedModel[];
  selectMaterials: SelectedModel[];
  selectSchool: SelectedModel[];
  isShown: boolean = false;
  options = [];
  courseNameId: number;
  traineeId: any;
  role: any;
  loggedTraineeId: any;
  branchId: any;
  schoolId: any;
  baseSchoolNameId: number;
  readingMaterialTitleId: number;
  onlineLibraryMaterial: any;
  public files: any[];
  progress: number = 0;
  btnShow = true;
  showSpinner = false;
  documentTypeId: any;
  IsAuthorNameShow: boolean = false;
  IsPublisherNameShow: boolean = false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  userId: string;
  onlineLibraryId: any


  filteredOptions;
  subscription: any;
  instractorData: any;
  searchText: string = "";

  displayedColumns: string[] = ['ser', 'documentName', 'aurhorName', 'documentLink', 'actions'];

  dataSource: MatTableDataSource<OnlineLibraryMaterial> = new MatTableDataSource();



  constructor(public dialog: MatDialog,
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private confirmService: ConfirmService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private instructorDashboardService: InstructorDashboardService,
    public sharedService: SharedServiceService,
    private onlineLibraryService: OnlinelibraryService
  ) {
    this.files = [];
  }

  ngOnInit(): void {
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    this.onlineLibraryId = this.route.snapshot.paramMap.get('onlineLibraryId');
    console.log(this.route.snapshot.paramMap.get('onlineLibraryId'));

    this.role = this.authService.currentUserValue.role.trim();
    this.loggedTraineeId = this.authService.currentUserValue.traineeId.trim();
    this.userId = this.authService.currentUserValue.id.trim();;


    if (this.authService.currentUserValue.branchId) {
      this.branchId = this.authService.currentUserValue.branchId.trim();
    }
    else {
      this.branchId = this.schoolId;
    }

    if (this.onlineLibraryId) {
      this.pageTitle = 'Edit Reading Material';
      this.destination = "Edit";
      this.buttonText = "Update"
      this.subscription = this.onlineLibraryService.find(+this.onlineLibraryId).subscribe(
        res => {
          console.log(this.getselectedDocumentType())
          this.onlineLibraryForm.patchValue({
            onlineLibraryId: res.onlineLibraryId,
            documentName: res.documentName,
            documentTypeId: res.documentTypeId,
            documentLink: res.documentLink,
            showRightId: res.showRightId,
            downloadRightId: res.downloadRightId,
            isApproved: res.isApproved,
            approvedDate: res.approvedDate,
            approvedUser: res.approvedUser,
            status: res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
            aurhorName : res.aurhorName,
            publisherName : res.publisherName
        
          });
          
          if (res.documentTypeId == 2){
            this.IsAuthorNameShow = true;
            this.IsPublisherNameShow = true;
          }
        }
      );
    } else {
      this.pageTitle = 'Post to E-Library';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    if (this.role != this.roleList.MasterAdmin) {
      this.onlineLibraryForm.get('baseSchoolNameId').setValue(this.branchId);

    }


    this.getselectedDocumentType();
    this.getselecteddownloadright();
    this.getOnlineLibraryMaterialsByUser();

  }

  intitializeForm() {
    this.onlineLibraryForm = this.fb.group({
      onlineLibraryId: [0],
      documentName: [''],
      baseSchoolNameId: [''],
      documentTypeId: [],
      documentLink: [''],
      doc: [''],
      showRightId: [0],
      downloadRightId: [''],
      isApproved: [true],
      approvedDate: [],
      approvedUser: [''],
      status: [1],
      isActive: [true],
      aurhorName: [''],
      publisherName: ['']
    })
  }

  onSubmit() {
    
    console.log(this.onlineLibraryId);
    this.onlineLibraryForm.get('approvedDate').setValue((new Date(this.onlineLibraryForm.get('approvedDate').value)).toUTCString());
    const formData = new FormData();
    for (const key of Object.keys(this.onlineLibraryForm.value)) {
      let value = this.onlineLibraryForm.value[key];
      if (value == null || value === undefined){
        value = ""
      }
      formData.append(key, value);
    }

    if (this.onlineLibraryId) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.onlineLibraryService.update(+this.onlineLibraryId, formData).subscribe(response => {

            this.sharedService.goBack();

            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    } else {
      this.loading = true;
      this.subscription = this.onlineLibraryService.submit(formData).subscribe((event: HttpEvent<any>) => {

        switch (event.type) {
          case HttpEventType.Sent:
            break;
          case HttpEventType.ResponseHeader:
            break;
          case HttpEventType.UploadProgress:
            this.progress = Math.round(event.loaded / event.total * 100);
            this.showSpinner = true;
            break;
          case HttpEventType.Response:

            setTimeout(() => {
              this.progress = 0;
            }, 1500);
            this.snackBar.open('Information Inserted Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
            this.showSpinner = false;
            this.sharedService.goBack();
        }

      }, error => {
        this.validationErrors = error;
      });


    }
  }

  getselectedDocumentType() {
    this.subscription = this.onlineLibraryService.getselectedDocumentType().subscribe(res => {
      this.selecteddocs = res
      this.selectDocument = res
    });
  }
  getselecteddownloadright() {
    this.subscription = this.onlineLibraryService.getselecteddownloadright().subscribe(res => {
      this.selecteddownload = res
    });
  }

  filterByDocs(value: any) {
    this.selecteddocs = this.selectDocument.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, '')))
  }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      if (file.size > 2147483648) {
        let tempDirection;
        if (localStorage.getItem('isRtl') === 'true') {
          tempDirection = 'rtl';
        } else {
          tempDirection = 'ltr';
        }
        const dialogRef = this.dialog.open(FileDialogMessageComponent, {
          direction: tempDirection,
        });
        this.btnShow = false;
      }

      else {
        this.btnShow = true;
      }
      this.onlineLibraryForm.patchValue({
        doc: file,
      });
    }
  }

  onDocumentTypeSelectionChange(event) {
    if (event.isUserInput) {
      this.documentTypeId = event.source.value;
      if (this.documentTypeId == 2) {
        this.IsAuthorNameShow = true;
        this.IsPublisherNameShow = true;
      }
      else {
        this.IsAuthorNameShow = false;
        this.IsPublisherNameShow = false;
      }
    }
  }
  getOnlineLibraryMaterialsByUser() {
    this.onlineLibraryService.getOnlineLibraryMaterialsByUser(this.paging.pageIndex, this.paging.pageSize, this.searchText, this.userId).subscribe(response => {
      this.dataSource.data = response.items;
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount
    })
  }



  deleteItem(row) {
    const id = row.onlineLibraryId;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.subscription = this.onlineLibraryService.delete(id).subscribe(() => {
          this.getOnlineLibraryMaterialsByUser();

          this.snackBar.open('Online Library Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })

  }

}
