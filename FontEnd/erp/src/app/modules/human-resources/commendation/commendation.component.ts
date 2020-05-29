import { Component, OnInit } from '@angular/core';
import { CommendationViewModal } from './commendation.model';

@Component({
  selector: 'app-commendation',
  templateUrl: './commendation.component.html',
  styleUrls: ['./commendation.component.css']
})
export class CommendationComponent implements OnInit {

  listColumnsName: string[] = ['name', 'description'];

  list: CommendationViewModal[] = [];

  constructor() { }

  ngOnInit(): void {
    this.list.push({
      id: 1,
      name: 'Hung',
      description: 'Tran Dinh Hung',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    });
  }

}
