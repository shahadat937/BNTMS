import { Component, OnInit, ChangeDetectionStrategy, inject, ViewChild } from '@angular/core';
import { delay, of, Subscription } from 'rxjs';
import {GlobalSearchService} from '../services/global-search.service'
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { PageEvent } from '@angular/material/paginator';

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
  previousKeywords: string;
  
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


  onSearch(delayed:boolean) {
    if(this.subscription) {
      this.subscription.unsubscribe();
    }

    if(this.searchText.trim()=="") {
      this.searchResults = [];
      return;
    }
    
    
    let delayedAmount = 0;

    if(delayed) {
      delayedAmount = 700
      this.pageIndex = 1;
    }


    let source$ = of (this.searchText);
    source$ = source$.pipe(
      delay(delayedAmount)
    );

    this.subscription = source$.subscribe(data => {
      this.globalSearchService.searchData(data,this.pageSize,this.pageIndex).subscribe({
        next: response => {
          this.searchResults = response;
          this.totalResult = response.totalResult;
        }
      })
    })
  }

  updatePage(event: PageEvent) {
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex+1;

    this.onSearch(false);
  }

}
