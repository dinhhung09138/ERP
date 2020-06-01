import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  navLinks: any[];
  activeLinkIndex = -1; 
  constructor(private router: Router) {
    this.navLinks = [
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
  }
  ngOnInit(): void {
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === this.router.url));
    });
  }

}
