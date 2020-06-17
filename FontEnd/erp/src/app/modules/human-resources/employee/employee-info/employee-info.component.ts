import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hr-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.css']
})
export class EmployeeInfoComponent implements OnInit {

  employeeTabs: any[] = [
    {
      label: 'Commendation',
      link: '/hr/employee/commendation',
      index: 0
    },
    {
      label: 'Contact',
      link: '/hr/employee/contact',
      index: 1
    },
    {
      label: 'Contract',
      link: '/hr/employee/contract',
      index: 2
    },
    {
      label: 'Dicipline',
      link: '/hr/employee/dicipline',
      index: 3
    },
    {
      label: 'Education',
      link: '/hr/employee/education',
      index: 4
    },
    {
      label: 'Identification',
      link: '/hr/employee/identification',
      index: 5
    },
    {
      label: 'Info',
      link: '/hr/employee/info',
      index: 6
    },
    {
      label: 'Relationship',
      link: '/hr/employee/relationship',
      index: 7
    },
  ];

  constructor() { }

  ngOnInit(): void {
  }

  reset() {

  }

  close() {

  }

}
