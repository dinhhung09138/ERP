import { RoleService } from './../../role.service';
import { RoleDetailInterface } from './../../role-detail.interface';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { FunctionInterface } from '../../../../../core/interfaces/function.interface';
import { FunctionCommandInterface } from './../../../../../core/interfaces/function-command.interface';

@Component({
  selector: 'app-system-role-permission',
  templateUrl: './permission.component.html',
  styleUrls: ['./permission.component.scss']
})
export class PermissionComponent implements OnInit {

  @Input() Function: FunctionInterface;
  @Input() Roles: RoleDetailInterface[] = [];
  @Output() listCommandSelected = new EventEmitter<FunctionCommandInterface[]>();

  form: FormGroup;

  get commands(): FormArray {
    return this.form.get('commands') as FormArray;
  }

  constructor(
    private fb: FormBuilder,
    private roleService: RoleService
    ) {
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      function: [false],
      commands: this.createCommandControlArray()
    });

    let checkAll = true;
    const listCommandsArray = this.form.get('commands') as FormArray;
    if (listCommandsArray.controls.length === 0) {
      checkAll = false;
    } else {
      for (const control of listCommandsArray.controls) {
        if (control.get('command').value === false) {
          checkAll = false;
        }
      }
    }
    this.form.get('function').setValue(checkAll);

    this.resetCommandFunctionsListener();
  }



  resetCommandFunctionsListener() {

    this.roleService.resetCommandInput.subscribe(status => {
      if (status === true) {

        this.form.get('function').setValue(false);

        const listCommandArray = this.form.get('commands') as FormArray;

        for (const control of listCommandArray.controls) {
          control.get('command').setValue(false);
        }

        for (const cmd of this.Function.commands) {
          cmd.selected = false;
        }
      }
    });

  }

  createCommandControlArray() {
    if (this.Function.commands === null) {
      return null;
    }
    const arr = this.Function.commands.map((cm: FunctionCommandInterface) => {
      return this.fb.group({
        command: [cm.selected]
      });
    });
    return new FormArray(arr);
  }

  checkAll(checked: boolean) {
    const outPutValue: FunctionCommandInterface[] = [];
    const listCommandArray = this.form.get('commands') as FormArray;

    for (const control of listCommandArray.controls) {
      control.get('command').setValue(checked);
    }
    for (const cmd of this.Function.commands) {
      cmd.selected = checked;
      outPutValue.push(cmd);
    }
    this.listCommandSelected.emit(outPutValue);
  }

  commandChecked(checked: boolean, commandId: number) {
    let checkAll = true;
    if (checked === false) {
      checkAll = checked;
    } else {
      const listCommandArray = this.form.get('commands') as FormArray;
      for (const control of listCommandArray.controls) {
        if (control.get('command').value === false) {
          checkAll = false;
        }
      }
    }
    this.form.get('function').setValue(checkAll);

    const cmd = this.Function.commands.find(m => m.id === commandId);
    cmd.selected = checked;

    const outPutValue: FunctionCommandInterface[] = [];
    outPutValue.push(cmd);


    this.listCommandSelected.emit(outPutValue);
  }

}
