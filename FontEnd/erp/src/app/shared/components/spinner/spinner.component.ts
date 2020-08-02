import { LoadingService } from './../../../core/services/loading.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit {

  @Input() IsLoading = false;

  constructor(private loadingService: LoadingService) { }

  ngOnInit(): void {
    this.loadingService.shareIsNavigationStatus.subscribe((status: boolean) => {
      this.IsLoading = status;
    });
  }

}
