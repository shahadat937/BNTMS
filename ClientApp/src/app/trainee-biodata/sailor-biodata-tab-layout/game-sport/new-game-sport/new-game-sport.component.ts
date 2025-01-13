import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GameSportService } from '../../service/GameSport.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../../src/app/shared/shared-service.service';
import { AuthService } from '../../../../../../src/app/core/service/auth.service';
import { Role } from '../../../../../../src/app/core/models/role';

@Component({
  selector: 'app-new-game-sport',
  templateUrl: './new-game-sport.component.html',
  styleUrls: ['./new-game-sport.component.sass']
})
export class NewGameSportComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  buttonText: string;
  loading = false;
  pageTitle: string;
  destination: string;
  traineeId: string;
  GameSportForm: FormGroup;
  validationErrors: string[] = [];
  gameValues: SelectedModel[];
  selectGame: SelectedModel[];
  role: string;
  userRoles = Role;

  constructor(private snackBar: MatSnackBar, private GameSportService: GameSportService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, private confirmService: ConfirmService, public sharedService: SharedServiceService, private authService: AuthService) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('gameSportId');
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.role = this.authService.currentUserValue.role;
    if (id) {
      this.pageTitle = 'Edit Game & Sport';
      this.destination = "Edit";
      this.buttonText = "Update"
      this.GameSportService.find(+id).subscribe(
        res => {
          this.GameSportForm.patchValue({

            gameSportId: res.gameSportId,
            traineeId: res.traineeId,
            gameId: res.gameId,
            //levelOfParticipation: res.levelOfParticipation,
            performance: res.performance,
            //additionalInformation: res.additionalInformation,

            //   menuPosition: res.menuPosition,
          });
        }
      );
    } else {
      this.pageTitle = 'Create Game & Sport';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    this.getGame();
  }
  intitializeForm() {
    this.GameSportForm = this.fb.group({
      gameSportId: [0],
      traineeId: [this.traineeId, Validators.required],
      gameId: ['', Validators.required],
      // levelOfParticipation: ['', Validators.required],
      performance: ['', Validators.required],
      //additionalInformation: [''],       
      //  menuPosition: ['', Validators.required],
      isActive: [true],

    })
  }

  getGame() {
    this.GameSportService.getselectedgame().subscribe(res => {
      this.gameValues = res
      this.selectGame = res
    });
  }
  filterByGame(value: any) {
    this.gameValues = this.selectGame.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, '')))
  }

  // If a trainee tries to view another trainee's information, it will be prevent.
  checkTraineeId(traineeId): boolean {
    if ((this.role === this.userRoles.Student || this.role === this.userRoles.Instructor)&& traineeId !== this.authService.currentUserValue.traineeId) {
      this.sharedService.goBack();
      return true;
    }
    return false;
  }



  onSubmit() {
    const id = this.GameSportForm.get('gameSportId')?.value;
    console.log(this.GameSportForm.value.traineeId);
    if (this.checkTraineeId(this.GameSportForm.value.traineeId)) {
      return; // Stop further execution if checkTraineeId returns true
    }
    if (id) {

      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.GameSportService.update(+id, this.GameSportForm.value).subscribe(response => {
            this.router.navigateByUrl('/trainee-biodata/sailor-biodata-tab/main-tab-layout/main-tab/game-sport-details/' + this.traineeId);
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
      this.GameSportService.submit(this.GameSportForm.value).subscribe(response => {
        this.router.navigateByUrl('/trainee-biodata/sailor-biodata-tab/main-tab-layout/main-tab/game-sport-details/' + this.traineeId);
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
