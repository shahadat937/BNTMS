import { Component, OnInit,ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { EducationalInstitution } from '../../models/EducationalInstitution';
import { EducationalInstitutionService } from '../../service/EducationalInstitution.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import{MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-educational-institution-list',
  templateUrl: './educational-institution-list.component.html',
  styleUrls: ['./educational-institution-list.component.sass']
})
export class EducationalInstitutionListComponent implements OnInit,OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: EducationalInstitution[] = [];
  isLoading = false;
  traineeId: string;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  //searchText="";

  displayedColumns: string[] = ['ser', 'instituteName','address','district','thana','classStudiedFrom','yearFrom', 'actions'];
  dataSource: MatTableDataSource<EducationalInstitution> = new MatTableDataSource();

  SelectionModel = new SelectionModel<EducationalInstitution>(true, []);
  subscription: any;

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private EducationalInstitutionService: EducationalInstitutionService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.getEducationalInstitutions();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getEducationalInstitutions() {
    this.isLoading = true;
    

    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.subscription = this.EducationalInstitutionService.getdatabytraineeid(+this.traineeId).subscribe(response => {     
     this.dataSource.data=response;
    })
  }
  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getEducationalInstitutions();
 
  // }
  // applyFilter(searchText: any){ 
  //   this.searchText = searchText;
  //   this.getEducationalInstitutions();
  // } 

  deleteItem(row) {
    const id = row.educationalInstitutionId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This EducationalInstitution Item').subscribe(result => {
      if (result) {
        this.subscription =  this.EducationalInstitutionService.delete(id).subscribe(() => {
          this.getEducationalInstitutions();
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
