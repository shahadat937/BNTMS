import { Component, OnInit,ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { GameSport } from '../../models/GameSport';
import { GameSportService } from '../../service/GameSport.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import{MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Component({
  selector: 'app-view-game-sport',
  templateUrl: './view-game-sport.component.html',
  styleUrls: ['./view-game-sport.component.sass']
})
export class ViewGameSportComponent implements OnInit,OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: GameSport[] = [];
  isLoading = false;
  gameSportId: number;
  traineeId: number;
  gameId: number;
  game: string;
  levelOfParticipation: string;
  performance: string;
  additionalInformation: string;
  gameValues:SelectedModel[];  
  subscription: any;

  

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private GameSportService: GameSportService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('gameSportId'); 
    this.subscription = this.GameSportService.find(+id).subscribe( res => {
      
      this.gameSportId = res.gameSportId,
      this.traineeId = res.traineeId,
      this.gameId = res.gameId,
      this.game = res.game,
      this.levelOfParticipation = res.levelOfParticipation,
      this.performance = res.performance,
      this.additionalInformation = res.additionalInformation             
    })
    //this.getGame();
  }

}
