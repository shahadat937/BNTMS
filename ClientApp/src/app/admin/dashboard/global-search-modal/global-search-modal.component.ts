import { Component, OnInit, ChangeDetectionStrategy, inject } from '@angular/core';
import { delay, of, Subscription } from 'rxjs';
import {GlobalSearchService} from '../services/global-search.service'
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';

@Component({
  selector: 'app-global-search-modal',
  templateUrl: './global-search-modal.component.html',
  styleUrls: ['./global-search-modal.component.sass'],
})
export class GlobalSearchModalComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  searchText: string;
  pageSize: number;
  pageIndex: number;
  subscription: Subscription = new Subscription();
  searchResults: any;
  totalResult : number;
  
  constructor(
    private globalSearchService: GlobalSearchService
  ) { 
    super();
    this.searchText= "";
    this.pageIndex = 1;
    this.pageSize = 5;
    this.totalResult = 0;
    this.searchResults = [];
  }

  

  ngOnInit(): void {
    
  }


  onSearch() {
    if(this.subscription) {
      this.subscription.unsubscribe();
    }

    if(this.searchText.trim()=="") {
      return;
    }

    let source$ = of (this.searchText);
    source$ = source$.pipe(
      delay(700)
    );

    this.subscription = source$.subscribe(data => {
      this.globalSearchService.searchData(data,this.pageSize,this.pageIndex).subscribe({
        next: response => {
          this.searchResults = response;
          this.totalResult = response.totalResult;
          console.log(this.searchResults);
        }
      })
    })
  }

  updatePage(event: any) {

  }

}
