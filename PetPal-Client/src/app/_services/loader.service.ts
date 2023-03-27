import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  loaderRequestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  loader() {
    this.loaderRequestCount++;
    this.spinnerService.show(undefined, {
      type: 'ball-clip-rotate',
      bdColor: 'rgba(255, 255, 255, 0)',
      color: '#333333'
    })
  }

  idle() {
    this.loaderRequestCount--;
    if(this.loaderRequestCount <= 0) {
      this.loaderRequestCount = 0;
      this.spinnerService.hide();
    }
  }
}
