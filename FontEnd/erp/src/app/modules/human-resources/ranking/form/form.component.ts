import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RankingService } from '../ranking.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { RankingViewModel } from '../ranking.model';

@Component({
  selector: 'app-hr-ranking-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class RankingFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  rankingForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private rankingService: RankingService) { }

  ngOnInit(): void {
    this.rankingForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.rankingForm.get('id').setValue(0);
    this.rankingForm.get('name').reset();
    this.rankingForm.get('precedence').reset();
    this.rankingForm.get('isActive').reset();

    if (isDisabledForm) {
      if (formStatus === FormActionStatus.UnKnow) {
        this.rankingForm.get('name').disable();
        this.rankingForm.get('precedence').disable();
        this.rankingForm.get('isActive').disable();
      } else {
        this.rankingForm.get('isActive').setValue(true);
        this.rankingForm.get('precedence').setValue(1);
        this.rankingForm.get('name').enable();
        this.rankingForm.get('precedence').enable();
        this.rankingForm.get('isActive').enable();
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
    if (this.rankingForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.rankingForm.value as RankingViewModel;
    model.action = this.formAction;

    this.rankingService.save(model).subscribe((res: ResponseModel) => {
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
    this.rankingService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.rankingForm.get('id').setValue(response.result.id);
        this.rankingForm.get('name').setValue(response.result.name);
        this.rankingForm.get('precedence').setValue(response.result.precedence);
        this.rankingForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
