import { Component, OnInit, Input } from '@angular/core';
import { FunctionInterface } from '../../../../../core/interfaces/function.interface';

@Component({
  selector: 'app-system-role-permission',
  templateUrl: './permission.component.html',
  styleUrls: ['./permission.component.scss']
})
export class PermissionComponent implements OnInit {

  @Input() Function: FunctionInterface;

  constructor() { }

  ngOnInit(): void {
  }

}
