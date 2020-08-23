import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { RoleService } from '../role.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';

@Component({
  selector: 'app-role-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class RoleFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  roleForm : FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private roleService: RoleService) {}

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
  initFormControl(formStatus: FormActionStatus){
    this.isSubmit = false;
    if(this.formDirective){
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
  }
  showFormStatus(){
    if(this.formAction == FormActionStatus.UnKnow){
      return false;
    }
    return true;
  }
  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
  }

  onResetClick() {
    this.initFormControl(this.formAction);
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  getItem(id:number){
    this.isLoading = true;
    this.roleService.item(id).subscribe((response: ResponseModel)=>{
      if (response !== null && response.responseStatus == ResponseStatus.success) {
        this.roleForm.get('id').setValue(response.result.id);
        this.roleForm.get('name').setValue(response.result.name);
        this.roleForm.get('description').setValue(response.result.description);
        this.roleForm.get('rowVersion').setValue(response.result.rowVersion);
        this.roleForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

  submitForm(){
    this.isSubmit = true;
    if(this.roleForm.invalid){
      return;
    }
    this.isLoading = true;  

    this.roleService.save(this.roleForm.getRawValue(), this.formAction).subscribe((res:ResponseModel)=>{
      if(res.responseStatus == ResponseStatus.success){
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });  
  }

}