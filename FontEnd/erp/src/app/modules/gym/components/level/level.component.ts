import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gym-level',
  templateUrl: './level.component.html',
  styleUrls: ['./level.component.css']
})
export class LevelComponent implements OnInit {

  showForm = false;

  constructor() { }

  ngOnInit(): void {
  }

  createLevel() {
    if (this.showForm) {
      return;
    }
    this.showForm = true;
  }

  editLevel(id) {
    this.showForm = true;
  }

  cancelLevel() {
    this.showForm = false;
  }

}
