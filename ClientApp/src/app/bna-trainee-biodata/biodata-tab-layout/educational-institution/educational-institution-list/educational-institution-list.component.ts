import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
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
import { UnsubscribeOnDestroyAdapter } from '../../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';

@Component({
  selector: 'app-educational-institution-list',
  templateUrl: './educational-institution-list.component.html',
  styleUrls: ['./educational-institution-list.component.sass']
})
export class EducationalInstitutionListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

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

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private EducationalInstitutionService: EducationalInstitutionService,private router: Router,private confirmService: ConfirmService) {
    super();
  }
  ngOnInit() {
    this.getEducationalInstitutions();
  }
 
  getEducationalInstitutions() {
    this.isLoading = true;
    

    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.EducationalInstitutionService.getdatabytraineeid(+this.traineeId).subscribe(response => {     
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
        this.EducationalInstitutionService.delete(id).subscribe(() => {
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
