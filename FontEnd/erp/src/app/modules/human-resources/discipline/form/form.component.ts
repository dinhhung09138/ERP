import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DisciplineService } from '../discipline.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { DisciplineViewModel } from '../discipline.model';

@Component({
  selector: 'app-hr-discipline-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class DisciplineFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  disciplineForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private disciplineService: DisciplineService) { }

  ngOnInit(): void {
    this.disciplineForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.disciplineForm.get('id').setValue(0);
    this.disciplineForm.get('name').reset();
    this.disciplineForm.get('description').reset();
    this.disciplineForm.get('isActive').reset();

    if (isDisabledForm) {
      if (formStatus === FormActionStatus.UnKnow) {
        this.disciplineForm.get('name').disable();
        this.disciplineForm.get('description').disable();
        this.disciplineForm.get('isActive').disable();
      } else {
        this.disciplineForm.get('isActive').setValue(true);
        this.disciplineForm.get('name').enable();
        this.disciplineForm.get('description').enable();
        this.disciplineForm.get('isActive').enable();
      }
    }
  }

  create() {
    this.initFormControl(FormActionStatus.Create);
  }

  update(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
  }

  reset() {
    this.initFormControl(this.formAction, false);
  }

  close() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.disciplineForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.disciplineForm.value as DisciplineViewModel;
    model.action = this.formAction;

    this.disciplineService.save(model).subscribe((res: ResponseModel) => {
      if (res !== null) {
        if (res.responseStatus === ResponseStatus.success) {
          this.initFormControl(FormActionStatus.UnKnow);
          this.reloadTableEvent.emit(true);
        }
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.disciplineService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.disciplineForm.get('id').setValue(response.result.id);
        this.disciplineForm.get('name').setValue(response.result.name);
        this.disciplineForm.get('description').setValue(response.result.description);
        this.disciplineForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
