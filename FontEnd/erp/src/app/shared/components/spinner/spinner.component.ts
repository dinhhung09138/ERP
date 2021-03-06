import { LoadingService } from './../../../core/services/loading.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent implements OnInit {

  @Input() isLoading = false;

  constructor(private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.loadingService.shareIsNavigationStatus.subscribe((status: boolean) => {
      this.isLoading = status;
    });
  }

}
