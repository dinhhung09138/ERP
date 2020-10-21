import { RankingService } from './../../../../configuration/ranking/ranking.service';
import { ModelOfStudyService } from './../../../../configuration/model-of-study/model-of-study.service';
import { EducationService } from './../../../../configuration/education/education.service';
import { EmployeeEducationService } from './../education.service';
import { ModelOfStudyViewModel } from './../../../../configuration/model-of-study/model-of-study.model';
import { RankingViewModel } from './../../../../configuration/ranking/ranking.model';
import { EducationViewModel } from './../../../../configuration/education/education.model';
import { EmployeeEducationViewModel } from './../education.model';
import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { ResponseModel } from '../../../../../../core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FormActionStatus } from '../../../../../../core/enums/form-action-status.enum';
import { DialogDataInterface } from '../../../../../../core/interfaces/dialog-data.interface';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeEducationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, { static: true}) formDirective: FormGroupDirective;

  formTitle = '';
  isLoading = false;
  isSubmit = false;
  employeeId = 0;
  form: FormGroup;
  formAction: FormActionStatus;
  listMajor: any[];
  listEducation: EducationViewModel[];
  listRank: RankingViewModel[];
  listModelOfStudy: ModelOfStudyViewModel[];
  listYear: number[];
  item: EmployeeEducationViewModel;

  constructor(
    private elm: ElementRef,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<EmployeeEducationFormComponent>,
    private fb: FormBuilder,
    private employeeEducationService: EmployeeEducationService,
    private educationTypeService: EducationService,
    private modelOfStudyService: ModelOfStudyService,
    private rankingService: RankingService,
  ) { }

  ngOnInit(): void {

    this.form = this.fb.group({
      id: [0],
      employeeId: [null, Validators.required],
      educationTypeId: ['', [Validators.required]],
      school: ['', [Validators.required, Validators.maxLength(255)]],
      majorId: ['', [Validators.required]],
      rankingId: ['', [Validators.required]],
      modelOfStudyId: ['', [Validators.required]],
      year: ['', [Validators.required]],
      isActive: [true],
      rowVersion: [null]
    });

    const currentYear = (new Date()).getFullYear();
    for (let i = currentYear; i > currentYear - 20; i --) {
      this.listYear.push(i);
    }

    this.formAction = FormActionStatus.Insert;
    if (this.dialogData && this.dialogData.isPopup === true) {
      this.listEducation = this.dialogData.listEducation;
      this.listMajor = this.dialogData.listMajor;
      this.listRank = this.dialogData.listRank;
      this.listModelOfStudy = this.dialogData.listModelOfStudy;
      this.employeeId = this.dialogData.employeeId;
      this.initFormControl(this.formAction);
      if (this.dialogData.itemId !== undefined) {
        this.formAction = FormActionStatus.Update;
        this.getItem(this.dialogData.itemId);
      }
    }
  }

  initFormControl(formAction: FormActionStatus) {
    this.isSubmit = false;

    this.formAction = formAction;
    this.form.get('id').setValue(0);
    this.form.get('employeeId').setValue(this.employeeId);
    this.form.get('educationTypeId').setValue('');
    this.form.get('school').reset();
    this.form.get('majorId').setValue('');
    this.form.get('rankingId').setValue('');
    this.form.get('modelOfStudyId').setValue('');
    this.form.get('year').setValue('');
    this.form.get('isActive').reset();

    if (formAction === FormActionStatus.UnKnow) {
      this.form.get('educationTypeId').disable();
      this.form.get('school').disable();
      this.form.get('majorId').disable();
      this.form.get('rankingId').disable();
      this.form.get('modelOfStudyId').disable();
      this.form.get('year').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('isActive').setValue(true);
      this.form.get('educationTypeId').enable();
      this.form.get('school').enable();
      this.form.get('majorId').enable();
      this.form.get('rankingId').enable();
      this.form.get('modelOfStudyId').enable();
      this.form.get('year').enable();
      this.form.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#educationTypeId').focus();
  }

  onResetClick() {
    this.initFormControl(this.formAction);
  }

  onCloseClick() {
    this.dialogRef.close(false);
  }

  onSubmit() {
    this.isSubmit = true;

    if (this.form.invalid) {
      return;
    }

    this.isLoading = true;
    this.employeeEducationService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.isLoading = false;
        this.dialogRef.close(true);
      }
    });
  }

  private getItem(itemId: number) {
    this.isLoading = true;
    this.employeeEducationService.item(itemId).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.setDataToForm(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EmployeeEducationViewModel) {
    if (data) {
      this.form.get('id').setValue(data.id);
      this.form.get('employeeId').setValue(this.employeeId);
      this.form.get('school').setValue(data.school);
      this.form.get('majorId').setValue(data.majorId);
      this.form.get('rankingId').setValue(data.rankingId);
      this.form.get('modelOfStudyId').setValue(data.modelOfStudyId);
      this.form.get('year').setValue(data.year);
      this.form.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
