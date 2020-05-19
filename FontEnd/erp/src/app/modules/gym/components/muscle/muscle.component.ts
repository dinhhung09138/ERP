import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gym-muscle',
  templateUrl: './muscle.component.html',
  styleUrls: ['./muscle.component.css']
})
export class MuscleComponent implements OnInit {

  showForm = false;
  constructor() { }

  ngOnInit(): void {
  }

  createMuscle() {
    if (this.showForm) {
      return;
    }
    this.showForm = true;
  }

  cancelMuscle() {
    this.showForm = false;
  }

  editMuscle(id: number): void {
    this.showForm = true;
  }

}
