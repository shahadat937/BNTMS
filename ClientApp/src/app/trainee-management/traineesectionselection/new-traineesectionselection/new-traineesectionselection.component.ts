import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TraineeSectionSelectionService } from '../../service/TraineeSectionSelection.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-TraineeSectionSelection',
  templateUrl: './new-TraineeSectionSelection.component.html',
  styleUrls: ['./new-TraineeSectionSelection.component.sass']
}) 
export class NewTraineeSectionSelectionComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  TraineeSectionSelectionForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse:SelectedModel[];
  selectedschool:SelectedModel[];
  selectedBnaBatch:SelectedModel[];
  selectedBnaSemester:SelectedModel[];
  selectedbnaclasssectionselection:SelectedModel[];
  selectPreview:SelectedModel[];
  selectClassSelection: SelectedModel[];
  selectedbnacurriculamtype:SelectedModel[];
  selectBNAbatch: SelectedModel[];
  selectSemesterId:SelectedModel[]

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private TraineeSectionSelectionService: TraineeSectionSelectionService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('traineeSectionSelectionId'); 
    if (id) {
      this.pageTitle = 'Edit Reading Material'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.TraineeSectionSelectionService.find(+id).subscribe(
        res => {
          this.TraineeSectionSelectionForm.patchValue({          
            traineeSectionSelectionId:res.traineeSectionSelectionId, 
            traineeId:res.traineeId,
            bnaBatchId: res.bnaBatchId, 
            bnaSemesterId:res.bnaSemesterId, 
            bnaClassSectionSelectionId:res.bnaClassSectionSelectionId, 
            previewsSectionId:res.previewsSectionId, 
            isApproved:res.isApproved, 
            approvedBy:res.approvedBy, 
            approvedDate:res.approvedDate, 
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Reading Material';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getBnaBatch();
    this.getBnaSemester();
    this.getbnaclasssectionselection();
    this.getbnacurriculamtype();
  }
  intitializeForm() {
    this.TraineeSectionSelectionForm = this.fb.group({
      traineeSectionSelectionId: [0],
      traineeId:[],  
      bnaBatchId:['',Validators.required],
      bnaSemesterId:['',Validators.required],
      bnaClassSectionSelectionId:['',Validators.required],
      previewsSectionId:[''],
      isApproved:[],
      approvedBy:[''],
      approvedDate:[],
      isActive: [true],    
    })
  }
  
  

  getBnaBatch(){
    this.TraineeSectionSelectionService.getselectedbnabatch().subscribe(res=>{
      this.selectedBnaBatch=res;
      this.selectBNAbatch=res;
    });
  }
  filterBnaBatch(value:any){
    this.selectedBnaBatch=this.selectBNAbatch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getBnaSemester(){
    this.TraineeSectionSelectionService.getselectedbnasemester().subscribe(res=>{
      this.selectedBnaSemester=res
      this.selectSemesterId=res      
    });
  }

  filterSemesterId(value:any){
    this.selectedBnaSemester=this.selectSemesterId.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getbnaclasssectionselection(){
    this.TraineeSectionSelectionService.getselectedbnaclasssectionselection().subscribe(res=>{
      this.selectedbnaclasssectionselection=res
      this.selectClassSelection=res  
      this.selectPreview=res    
    });
  }
 filterClassSelection(value:any){
  this.selectedbnaclasssectionselection=this.selectClassSelection.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
 }
filterPreviewSection(value:any){
  this.selectedbnaclasssectionselection=this.selectPreview.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
  getbnacurriculamtype(){
    this.TraineeSectionSelectionService.getselectedbnacurriculamtype().subscribe(res=>{
      this.selectedbnacurriculamtype=res      
    });
  }

  onSubmit() {
    const id = this.TraineeSectionSelectionForm.get('traineeSectionSelectionId')?.value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.TraineeSectionSelectionService.update(+id,this.TraineeSectionSelectionForm.value).subscribe(response => {
            this.router.navigateByUrl('/trainee-management/traineesectionselection-list');
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
    }else {
      this.loading = true;
      this.TraineeSectionSelectionService.submit(this.TraineeSectionSelectionForm.value).subscribe(response => {
        this.router.navigateByUrl('/trainee-management/traineesectionselection-list');
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
