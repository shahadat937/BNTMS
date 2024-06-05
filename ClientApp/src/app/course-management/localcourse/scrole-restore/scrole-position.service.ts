import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ScrollService {
  private scrollPositions: { [key: string]: number } = {};
  private filters: { [key: string]: number } = {};
  private index: { [key: string]: number } = {'':0};

  setScrollPosition(componentName: string, position: number) {
    this.scrollPositions[componentName] = position;
  }

  getScrollPosition(componentName: string): number {
    return this.scrollPositions[componentName] || 0;
  }

  setSelectedFilter(componentName: string, position: number) {
   this.filters[componentName] = position;
  }

  getSelectedFilter(componentName: string): number {
   return this.filters[componentName] || 1;
  }
  
  setSelectedIndex(componentName: string, position: number) {
    this.index[componentName] = position;
   }
 
   getSelectedIndex(componentName: string): number {
    return this.index[componentName];
   }
}
