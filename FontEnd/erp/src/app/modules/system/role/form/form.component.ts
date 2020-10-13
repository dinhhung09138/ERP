import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef, Input } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { RoleService } from '../role.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { RoleViewModel } from '../role.model';
import { RoleDetailViewModel } from '../role-detail.model';
import { ModuleViewModel } from '../../../../core/models/module.model';
import { FunctionCommandViewModel } from '../../../../core/models/function-command.model';

@Component({
  selector: 'app-role-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class RoleFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Input() ListModule: ModuleViewModel[];
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  roleForm: FormGroup;
  item: RoleViewModel;
  currentModule: ModuleViewModel[];
  roleDetails: RoleDetailViewModel[] = [];

  constructor(
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private roleService: RoleService) {
    }

  ngOnInit(): void {
    this.permission = this.roleService.getPermission();
    this.roleForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true],
      rowVersion: [null]
    });
    this.initFormControl(this.formAction);
  }

  commandSelectedListener(commands: FunctionCommandViewModel[]) {
    for (const cmd of commands) {
      if (cmd.selected === true) {
        const checkExists = this.roleDetails.some(detail => {
          return detail.commandId === cmd.id;
        });
        if (checkExists === false) {
          const roleDetail = {
            commandId: cmd.id,
            roleId: 0
          } as RoleDetailViewModel;

          this.roleDetails.push(roleDetail);
        }
      } else {
        this.roleDetails = this.roleDetails.filter(m => m.commandId !== cmd.id);
      }
    }
  }

  initFormControl(formStatus: FormActionStatus){
    this.isSubmit = false;

    this.currentModule = [];
    this.roleDetails = [];
    if (this.ListModule) {
      this.currentModule = [...this.ListModule];
    }

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
    this.roleService.startResetCommandInputForm();
    switch (this.formAction) {
      case FormActionStatus.Insert:
        this.initFormControl(this.formAction);
        break;
      case FormActionStatus.Update:
        this.setDataToForm(this.item);
        this.roleService.passingRoleDetailsData(this.item);
        this.elm.nativeElement.querySelector('#name').focus();
        break;
    }
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  getListParentFunctionWithoutChild(moduleCode: string) {
    const module = this.ListModule.find(m => m.code === moduleCode);
    const f = module.functions.filter(m => m.parentCode === '').sort(m => m.precedence);
    return f;
  }

  getListParentFunctionHasChild(moduleCode: string) {
    const module = this.ListModule.find(m => m.code === moduleCode);
    const f = module.functions.filter(m => m.parentCode === ''
                                      && module.functions.some(c => c.parentCode === m.code))
                              .sort(m => m.precedence);
    return f;
  }

  getListChildFunction(moduleCode: string, functionCode: string) {
    const module = this.ListModule.find(m => m.code === moduleCode);
    return module.functions.filter(m => m.parentCode === functionCode).sort(m => m.precedence);
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
    if (this.roleForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.roleService.save(this.roleForm.getRawValue(), this.roleDetails, this.formAction).subscribe((res: ResponseModel) => {
      if (res.responseStatus === ResponseStatus.success){
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private setDataToForm(data: RoleViewModel) {
    const moduleList = [...this.ListModule];
    for (const r of data.roles) {
      for (const m of moduleList) {
        for (const f of m.functions) {
          const c = f.commands.find(t => t.id === r.commandId);
          if (c) {
            c.selected = true;
          }
        }
      }
    }
    this.currentModule = [...moduleList];
    this.roleDetails = data.roles;
    this.roleForm.get('id').setValue(data.id);
    this.roleForm.get('name').setValue(data.name);
    this.roleForm.get('description').setValue(data.description);
    this.roleForm.get('isActive').setValue(data.isActive);
    this.roleForm.get('rowVersion').setValue(data.rowVersion);
  }
}
