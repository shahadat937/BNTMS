import { Component, OnInit } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseLevelService } from '../service/course-level.service';
import { BaseSchoolNameService } from '../../basic-setup/service/BaseSchoolName.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import{MasterData} from 'src/assets/data/master-data';
import { CourseLevel } from '../models/course-level';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';


@Component({
  selector: 'app-course-level',
  templateUrl: './course-level.component.html',
  styleUrls: ['./course-level.component.sass']
})
export class CourseLevelComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  pageTitle: string;
  loading = false;
  destination:string;
  btnText:string;
  CourseLevelForm: FormGroup;
  validationErrors: string[] = [];
  selectedSchool:SelectedModel[];
  selectSchool:SelectedModel[];


  
  masterData = MasterData;
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'courseLeveTitle', 'isActive', 'actions'];
  dataSource: MatTableDataSource<CourseLevel> = new MatTableDataSource();



  constructor(private baseSchoolNameService: BaseSchoolNameService , private snackBar: MatSnackBar,private confirmService: ConfirmService,private CourseLevelService: CourseLevelService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) {
    super();
  }

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('courseLevelId'); 
    if (id) {
      this.pageTitle = 'Edit Course Level Group';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.CourseLevelService.find(+id).subscribe(
        res => {
          this.CourseLevelForm.patchValue({          

            courseLevelId: res.courseLevelId,
            courseLeveTitle: res.courseLeveTitle,
            baseSchoolNameId : res.baseSchoolNameId,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Course Level ';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();

    this.getSelectedbaseSchoolName();
    this.getCourseLevels();

  }
  intitializeForm() {
    this.CourseLevelForm = this.fb.group({
      courseLevelId: [0],
      courseLeveTitle: ['', Validators.required],
      baseSchoolNameId :[0],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }
  

 
 

  getCourseLevels() {
  this.isLoading = true;
  this.CourseLevelService.getCourseLevels(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
    
    this.dataSource.data = response.items; 
    this.paging.length = response.totalItemsCount    
    this.isLoading = false;
  })
}

pageChanged(event: PageEvent) {
  this.paging.pageIndex = event.pageIndex
  this.paging.pageSize = event.pageSize
  this.paging.pageIndex = this.paging.pageIndex + 1
  this.getCourseLevels();
}

applyFilter(searchText: any){ 
  this.searchText = searchText;
  this.getCourseLevels();
} 

deleteItem(row) {
  const id = row.courseLevelId; 
  this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
    if (result) {
      this.CourseLevelService.delete(id).subscribe(() => {
        this.getCourseLevels();
        this.snackBar.open('Information Deleted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-danger'
        });
      })
    }
  })    
}

  getSelectedbaseSchoolName(){
    this.baseSchoolNameService.getselectedSchools().subscribe(res=>{
      this.selectedSchool=res
      this.selectSchool=res
    });
   }
   filterBySchool(value:any){
    this.selectedSchool=this.selectSchool.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
   }


  onSubmit() {
    const id = this.CourseLevelForm.get('courseLevelId').value;   

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.CourseLevelService.update(+id,this.CourseLevelForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-courseLevel');
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
    } 

 else {
  this.loading=true;
      this.CourseLevelService.submit(this.CourseLevelForm.value).subscribe(response => {
        this.router.navigateByUrl('/basic-setup/add-courseLevel');
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
