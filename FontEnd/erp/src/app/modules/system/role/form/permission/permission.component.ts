import { FormGroup, FormBuilder, FormControl, FormArray } from '@angular/forms';
import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

import { FunctionInterface } from '../../../../../core/interfaces/function.interface';
import { FunctionCommandInterface } from './../../../../../core/interfaces/function-command.interface';
import { throwIfEmpty } from 'rxjs/operators';

@Component({
  selector: 'app-system-role-permission',
  templateUrl: './permission.component.html',
  styleUrls: ['./permission.component.scss']
})
export class PermissionComponent implements OnInit, OnChanges {

  @Input() Function: FunctionInterface;
  @Output() listCommandSelected = new EventEmitter<FunctionCommandInterface[]>();

  form: FormGroup;

  get commands(): FormArray {
    return this.form.get('commands') as FormArray;
  }

  constructor(private fb: FormBuilder) {
    console.log('constructor');
  }

  ngOnInit(): void {
    console.log('init');
    this.form = this.fb.group({
      function: [false],
      commands: this.createCommandControlArray()
    });
  }

  ngOnChanges(changes: SimpleChanges) {
  }

  resetCommandFunctions() {
    console.log('reset');
    const listCommandArray = this.form.get('commands') as FormArray;
    console.log(listCommandArray.controls);
    listCommandArray.controls.forEach((value, idx) => {
      console.log(idx);
      console.log(value);
    });
  }

  createCommandControlArray() {
    if (this.Function.commands === null) {
      return null;
    }
    console.log(this.Function);
    const arr = this.Function.commands.map(cm => {
      console.log(cm.selected);
      return new FormControl(cm.selected);
    });
    console.log(arr);
    return new FormArray(arr);
  }

  checkAll(checked: boolean) {
    const outPutValue: FunctionCommandInterface[] = [];
    const listCommandArray = this.form.get('commands') as FormArray;

    for (const control of listCommandArray.controls) {
      control.setValue(checked);
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
        if (control.value === false) {
          checkAll = control.value;
          break;
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
