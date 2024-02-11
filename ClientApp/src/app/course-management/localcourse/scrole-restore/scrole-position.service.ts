import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ScrollService {
  private scrollPositions: { [key: string]: number } = {};
  private oldScrollPositions: { [key: string]: number } = {};

  setScrollPosition(componentName: string, position: number) {
    this.scrollPositions[componentName] = position;
  }

  getScrollPosition(componentName: string): number {
    return this.scrollPositions[componentName] || 0;
  }

  setSelectedFilter(componentName: string, position: number) {
   this.oldScrollPositions[componentName] = position;
  }

  getSelectedFilter(componentName: string): number {
   return this.oldScrollPositions[componentName] || 1;
  }
}
