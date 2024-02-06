// scroll-position.service.ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ScrollService {
  private scrollPositions: { [url: string]: number } = {};

  saveScrollPosition(url: string, position: number): void {
    this.scrollPositions[url] = position;
  }

  getScrollPosition(url: string): number {
    return this.scrollPositions[url] || 0;
  }
}
