import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionService } from '../../service/Question.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';

@Component({
  selector: 'app-new-question',
  templateUrl: './new-question.component.html',
  styleUrls: ['./new-question.component.sass']
})
export class NewQuestionComponent implements OnInit,OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  traineeId:  string;
  QuestionForm: FormGroup;
  validationErrors: string[] = [];
  typeValues:SelectedModel[]; 
  selectQuestionType:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private QuestionService: QuestionService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('questionId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    
    if (id) {
      this.pageTitle = 'Edit Question';
      this.destination = "Edit";
      this.buttonText= "Update"
     this.subscription = this.QuestionService.find(+id).subscribe(
        res => {
          this.QuestionForm.patchValue({          

            questionId: res.questionId,
            traineeId: res.traineeId,
            
            questionTypeId: res.questionTypeId,
            answer: res.answer,
            additionalInformation: res.additionalInformation,
                                   
         //   menuPosition: res.menuPosition,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Question';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.getQuestionType();
    //this.getThana();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.QuestionForm = this.fb.group({
      questionId: [0],
      traineeId: [this.traineeId, Validators.required],
      questionTypeId: ['', Validators.required],
      answer: ['', Validators.required],
      additionalInformation: [],
                
    //  menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }

  getQuestionType(){
    this.subscription = this.QuestionService.getselectedquestiontype().subscribe(res=>{
      this.typeValues=res
      this.selectQuestionType=res
    });
  }
  filterByType(value:any){
    this.typeValues=this.selectQuestionType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  

  
  onSubmit() {
    const id = this.QuestionForm.get('questionId').value; 
      
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.QuestionService.update(+id,this.QuestionForm.value).subscribe(response => {
            this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/question-details/'+this.traineeId);
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
      this.loading=true;
      this.subscription = this.QuestionService.submit(this.QuestionForm.value).subscribe(response => {
        this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/question-details/'+this.traineeId);
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
