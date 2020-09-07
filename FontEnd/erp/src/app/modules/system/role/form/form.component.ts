import { FunctionCommandInterface } from './../../../../core/interfaces/function-command.interface';
import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { RoleService } from '../role.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { RoleViewModel } from '../role.model';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from 'src/app/core/constants/app.constant';
import { ModuleInterface } from '../../../../core/interfaces/module.interface';

@Component({
  selector: 'app-role-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class RoleFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  roleForm: FormGroup;
  item: RoleViewModel;
  listModule: ModuleInterface[];
  listCommandSelected: FunctionCommandInterface[] = [];

  constructor(
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private roleService: RoleService) {
    }

  ngOnInit(): void {
    this.roleForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true],
      rowVersion: [null]
    });
    this.initFormControl(this.formAction);
  }

  commandSelectedListener(commands: FunctionCommandInterface[]) {
    for (const cmd of commands) {
      if (cmd.selected === true) {
        this.listCommandSelected.push(cmd);
      } else {
        this.listCommandSelected = this.listCommandSelected.filter(m => m.id !== cmd.id);
      }
    }
  }

  initFormControl(formStatus: FormActionStatus){
    this.isSubmit = false;

    if (this.formDirective){
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.roleForm.get('id').setValue(0);
    this.roleForm.get('name').reset();
    this.roleForm.get('description').reset();
    this.roleForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.roleForm.get('name').disable();
      this.roleForm.get('description').disable();
      this.roleForm.get('isActive').disable();
    } else {
      this.roleForm.get('isActive').setValue(true);
      this.roleForm.get('name').enable();
      this.roleForm.get('description').enable();
      this.roleForm.get('isActive').enable();
      this.elm.nativeElement.querySelector('#name').focus();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  setListModule(listModule: ModuleInterface[]) {
    this.listModule = listModule;
  }

  showFormStatus(){
    if (this.formAction === FormActionStatus.UnKnow){
      return false;
    }
    return true;
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#name').focus();
    this.translate.get('SCREEN.SYSTEM.ROLE.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.SYSTEM.ROLE.FORM.TITLE_EDIT').subscribe(message => {
      this.formTitle = message;
    });
  }

  onResetClick() {
    switch (this.formAction) {
      case FormActionStatus.Insert:
        this.initFormControl(this.formAction);
        break;
      case FormActionStatus.Update:
        this.setDataToForm(this.item);
        this.elm.nativeElement.querySelector('#name').focus();
        break;
    }
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  getItem(id: number){
    this.isLoading = true;
    this.roleService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  submitForm(){
    this.isSubmit = true;
    if (this.roleForm.invalid){
      return;
    }
    this.isLoading = true;

    this.roleService.save(this.roleForm.getRawValue(), this.formAction).subscribe((res: ResponseModel) => {
      if (res.responseStatus === ResponseStatus.success){
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private setDataToForm(data: RoleViewModel) {
    this.roleForm.get('id').setValue(data.id);
    this.roleForm.get('name').setValue(data.name);
    this.roleForm.get('description').setValue(data.description);
    this.roleForm.get('isActive').setValue(data.isActive);
    this.roleForm.get('rowVersion').setValue(data.rowVersion);
  }
}
