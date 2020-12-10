import { Component, OnInit, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from '@angular/router';

import { TranslateService } from '@ngx-translate/core';
import { DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';

import { EmployeeWorkingStatusViewModel } from './../../configuration/employee-working-status/employee-working-status.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { APP_DATE_FORMATS, AppDateAdapter } from 'src/app/core/helpers/format-datepicker.helper';
import { EmployeeService } from '../employee.service';
import { EmployeeViewModel } from '../employee.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';
import { ApplicationConstant } from '../../../../core/constants/app.constant';
import { EmployeeRelationshipComponent } from './relationship/relationship.component';
import { EmployeeIdentificationComponent } from './identification/identification.component';
import { EmployeeEducationComponent } from './education/education.component';
import { PersonalInfoComponent } from './personal-info/personal-info.component';
import { PermissionViewModel } from '../../../../core/models/permission.model';
import { DialogService } from '../../../../core/services/dialog.service';
import { PositionViewModel } from '../../position/position.model';
import { EmployeeCertificateComponent } from './certificate/certificate.component';
import { EmployeeContactComponent } from './contact/contact.component';
import { EmployeeBankComponent } from './bank/bank.component';

@Component({
  selector: 'app-hr-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss'],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
    { provide: DateAdapter, useClass: AppDateAdapter }
  ]
})
export class EmployeeInfoComponent implements OnInit, AfterViewInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  permission = new PermissionViewModel();
  employeeForm: FormGroup;
  isLoading = false;
  isSubmit = false;
  panelTitle = '';

  formAction = FormActionStatus.UnKnow;
  isEditEmployee = false;
  currentSelectedEmployeeId = 0;
  currentSelectedEmployee: EmployeeViewModel;

  fileToUpload: any;
  fileUrl: string;

  personalInfoPermission = new PermissionViewModel();
  initPersonInfoTab = false;
  @ViewChild(PersonalInfoComponent) personalInfoTab: PersonalInfoComponent;
  educationPermission = new PermissionViewModel();
  initEducationTab = false;
  @ViewChild(EmployeeEducationComponent) educationTab: EmployeeEducationComponent;
  relationshipPermission = new PermissionViewModel();
  initRelationshipTab = false;
  @ViewChild(EmployeeRelationshipComponent) relationshipTab: EmployeeRelationshipComponent;
  identificationPermission = new PermissionViewModel();
  initIdentificationTab = false;
  @ViewChild(EmployeeIdentificationComponent) identificationTab: EmployeeIdentificationComponent;
  certificatePermission = new PermissionViewModel();
  initCertificateTab = false;
  @ViewChild(EmployeeCertificateComponent) certificateTab: EmployeeCertificateComponent;
  contactPermission = new PermissionViewModel();
  initContactTab = false;
  @ViewChild(EmployeeContactComponent) contactTab: EmployeeContactComponent;
  bankPermission = new PermissionViewModel();
  initBankTab = false;
  @ViewChild(EmployeeBankComponent) bankTab: EmployeeBankComponent;

  listWorkingStatus: EmployeeWorkingStatusViewModel[] = [];
  listPosition: PositionViewModel[] = [];

  constructor(
    public translate: TranslateService,
    private fb: FormBuilder,
    private elm: ElementRef,
    private router: Router,
    private titleService: Title,
    private activatedRoute: ActivatedRoute,
    private formatNumber: FormatNumberPipe,
    private employeeService: EmployeeService,
    private dialog: DialogService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeService.getPermission();
    if (this.permission.allowInsert === false && this.permission.allowUpdate === false) {
      this.dialog.openUnauthorizeDialog();
      return;
    }

    this.personalInfoPermission = this.employeeService.getPersonalInfoPermission();
    this.educationPermission = this.employeeService.getEducationPermission();
    this.relationshipPermission = this.employeeService.getRelationshipPermission();
    this.identificationPermission = this.employeeService.getIdentificationPermission();
    this.certificatePermission = this.employeeService.getCertificatePermission();
    this.contactPermission = this.employeeService.getContactPermission();
    this.bankPermission = this.employeeService.getBankPermission();

    this.activatedRoute.data.subscribe(response => {
      this.listWorkingStatus = response.data?.listWorkingStatus?.result || [];
      this.listPosition = response.data?.listPosition?.result || [];
    });

    this.employeeForm = this.fb.group({
      id: [0],
      employeeCode: ['', [Validators.required]],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      workingEmail: ['', [Validators.email]],
      workingPhone: [''],
      badgeCardNumber: [''],
      dateApplyBadge: [null, [AppValidator.date]],
      fingerSignNumber: [''],
      dateApplyFingerSign: [null, [AppValidator.date]],
      probationDate: [null, [AppValidator.date]],
      startWorkingDate: [null, [AppValidator.date]],
      employeeWorkingStatusId: [''],
      currentPositionId: [''],
      currentDepartmentId: [''],
      basicSalary: [0, [AppValidator.money, Validators.required]],
      rowVersion: [null],
    });
    this.initFormControl(this.formAction);
    this.checkFormAction();
  }

  ngAfterViewInit(){
    if (this.router.url.indexOf('/employee/edit') > 0 && this.personalInfoPermission.allowView === true) {
      this.initPersonInfoTab = true;
      this.personalInfoTab.getSelection();
    }
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.fileToUpload = null;
    this.fileUrl = null;

    this.formAction = formStatus;
    this.employeeForm.get('id').setValue(0);
    this.employeeForm.get('employeeCode').setValue('');
    this.employeeForm.get('firstName').setValue('');
    this.employeeForm.get('lastName').setValue('');
    this.employeeForm.get('workingEmail').setValue('');
    this.employeeForm.get('workingPhone').setValue('');
    this.employeeForm.get('badgeCardNumber').setValue('');
    this.employeeForm.get('dateApplyBadge').setValue(null);
    this.employeeForm.get('fingerSignNumber').setValue('');
    this.employeeForm.get('dateApplyFingerSign').setValue(null);
    this.employeeForm.get('probationDate').setValue(null);
    this.employeeForm.get('startWorkingDate').setValue(null);
    this.employeeForm.get('employeeWorkingStatusId').setValue('');
    this.employeeForm.get('currentPositionId').setValue('');
    this.employeeForm.get('currentDepartmentId').setValue('');
    this.employeeForm.get('basicSalary').setValue(0);

    if (this.formAction === FormActionStatus.UnKnow) {
      this.employeeForm.get('employeeCode').disable();
      this.employeeForm.get('firstName').disable();
      this.employeeForm.get('lastName').disable();
      this.employeeForm.get('workingEmail').disable();
      this.employeeForm.get('workingPhone').disable();
      this.employeeForm.get('badgeCardNumber').disable();
      this.employeeForm.get('dateApplyBadge').disable();
      this.employeeForm.get('fingerSignNumber').disable();
      this.employeeForm.get('dateApplyFingerSign').disable();
      this.employeeForm.get('probationDate').disable();
      this.employeeForm.get('startWorkingDate').disable();
      this.employeeForm.get('employeeWorkingStatusId').disable();
      this.employeeForm.get('currentPositionId').disable();
      this.employeeForm.get('currentDepartmentId').disable();
      this.employeeForm.get('basicSalary').disable();
    } else {
      this.employeeForm.get('firstName').enable();
      this.employeeForm.get('lastName').enable();
      this.employeeForm.get('workingEmail').enable();
      this.employeeForm.get('workingPhone').enable();
      this.employeeForm.get('badgeCardNumber').enable();
      this.employeeForm.get('dateApplyBadge').enable();
      this.employeeForm.get('fingerSignNumber').enable();
      this.employeeForm.get('dateApplyFingerSign').enable();
      this.employeeForm.get('probationDate').enable();
      this.employeeForm.get('startWorkingDate').enable();
      this.employeeForm.get('employeeWorkingStatusId').enable();
      this.employeeForm.get('currentPositionId').enable();
      this.employeeForm.get('currentDepartmentId').enable();
      this.employeeForm.get('basicSalary').enable();

      if (this.formAction === FormActionStatus.Insert) {
        this.employeeForm.get('employeeCode').enable();
        this.elm.nativeElement.querySelector('#employeeCode').focus();
      } else {
        this.employeeForm.get('employeeCode').disable();
        this.elm.nativeElement.querySelector('#firstName').focus();
      }
    }
  }

  /**
   * Checking when user add new or update employee
   */
  checkFormAction() {
    if (this.router.url.indexOf('/employee/new') > 0) {
      this.initFormControl(FormActionStatus.Insert);
      this.isEditEmployee = true;
      this.setTitle();
    } else if (this.router.url.indexOf('/employee/edit/') > 0) {
      this.initFormControl(FormActionStatus.Update);
      const id = this.activatedRoute.snapshot.paramMap.get('id');
      this.currentSelectedEmployeeId = parseInt(id, 0);
      this.getEmployeeInfo(this.currentSelectedEmployeeId);
    }
  }

  onEditClick() {
    this.isEditEmployee = true;
  }

  onCancelClick() {
    this.isEditEmployee = false;
    this.initFormControl(this.formAction);
    this.setDataToFormControl(this.currentSelectedEmployee);
  }

  onResetClick() {
    this.initFormControl(this.formAction);
    this.setDataToFormControl(this.currentSelectedEmployee);
  }

  onCloseClick() {
    this.router.navigate(['/hr/employee']);
  }

  onSelectFile(files: FileList) {
    if (files.length === 0) {
      return;
    }
    if (files.item(0).size > (2 * 1024 * 1024)) {
      alert(files.item(0).size);
      return;
    }
    this.fileToUpload = files.item(0);

    const fileReader: FileReader = new FileReader();
    fileReader.readAsDataURL(this.fileToUpload);
    fileReader.onload = (event: any) => {
      this.fileUrl = event.target.result;
    };

  }

  onSelectTab(tabName: string) {
    switch (tabName) {
      case 'personalInfo':
        if (this.initPersonInfoTab === false && this.personalInfoPermission.allowView === true) {
          this.initPersonInfoTab = true;
          this.personalInfoTab.getSelection();
        }
        break;
      case 'contact':
        if (this.initContactTab === false && this.contactPermission.allowView === true) {
          this.initContactTab = true;
          this.contactTab.getSelection();
        }
        break;
      case 'relationship':
        if (this.initRelationshipTab === false && this.relationshipPermission.allowView === true) {
          this.initRelationshipTab = true;
          this.relationshipTab.getList();
          this.relationshipTab.getListRelationshipType();
        }
        break;
      case 'identification':
        if (this.initIdentificationTab === false && this.identificationPermission.allowView === true) {
          this.initIdentificationTab = true;
          this.identificationTab.getList();
          this.identificationTab.getIdentificationType();
          this.identificationTab.getProvince();
        }
        break;
      case 'education':
        if (this.initEducationTab === false && this.educationPermission.allowView === true) {
          this.initEducationTab = true;
          this.educationTab.getList();
          this.educationTab.getEducationType();
          this.educationTab.getModelOfStudyType();
          this.educationTab.getRanking();
          this.educationTab.getMajor();
          this.educationTab.getSchool();
        }
        break;
      case 'certificate':
        if (this.initCertificateTab === false && this.certificatePermission.allowView === true) {
          this.initCertificateTab = true;
          this.certificateTab.getList();
          this.certificateTab.getCertificated();
          this.certificateTab.getSchool();
        }
        break;
      case 'bank':
        if (this.initBankTab === false && this.bankPermission.allowView === true) {
          this.initBankTab = true;
          this.bankTab.getList();
          this.bankTab.getBank();
        }
        break;
    }
  }

  submitForm() {
    this.isSubmit = true;
    if (this.employeeForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.employeeService.save(this.employeeForm.getRawValue(), this.formAction, this.fileToUpload).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.currentSelectedEmployee = response.result;
        this.currentSelectedEmployeeId = response.result.id;
        this.setDataToFormControl(this.currentSelectedEmployee);
        this.isEditEmployee = false;
        this.formAction = FormActionStatus.Update;
      }
      this.isSubmit = false;
      this.isLoading = false;
    });
  }

  private setTitle(name?: string) {
    if (name) {
      this.translate.get('SCREEN.HR.EMPLOYEE.TITLE').subscribe(message => {
        this.panelTitle = message + ': ' + name;
        this.titleService.setTitle(name + ApplicationConstant.siteTitle);
      });
    } else {
      this.translate.get('SCREEN.HR.EMPLOYEE.FORM.TITLE_NEW').subscribe(message => {
        this.panelTitle = message;
        this.titleService.setTitle(message + ApplicationConstant.siteTitle);
      });
    }
  }

  private getEmployeeInfo(id: number) {
    this.isLoading = true;

    this.employeeService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.currentSelectedEmployee = response.result;
        this.setDataToFormControl(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToFormControl(data?: EmployeeViewModel) {
    if (data) {
      this.setTitle(data.fullName);
      this.employeeForm.get('id').setValue(data.id);
      this.employeeForm.get('employeeCode').setValue(data.employeeCode);
      this.employeeForm.get('firstName').setValue(data.firstName);
      this.employeeForm.get('lastName').setValue(data.lastName);
      this.employeeForm.get('workingEmail').setValue(data.workingEmail);
      this.employeeForm.get('workingPhone').setValue(data.workingPhone);
      this.employeeForm.get('badgeCardNumber').setValue(data.badgeCardNumber);
      if (data.dateApplyBadge) {
        this.employeeForm.get('dateApplyBadge').setValue(new Date(data.dateApplyBadge));
      }
      this.employeeForm.get('fingerSignNumber').setValue(data.fingerSignNumber);

      if (data.dateApplyFingerSign) {
        this.employeeForm.get('dateApplyFingerSign').setValue(new Date(data.dateApplyFingerSign));
      }
      if (data.probationDate) {
        this.employeeForm.get('probationDate').setValue(new Date(data.probationDate));
      }
      if (data.startWorkingDate) {
        this.employeeForm.get('startWorkingDate').setValue(new Date(data.startWorkingDate));
      }
      this.employeeForm.get('employeeWorkingStatusId').setValue(data.employeeWorkingStatusId);
      this.employeeForm.get('currentPositionId').setValue(data.currentPositionId);
      this.employeeForm.get('currentDepartmentId').setValue(data.currentDepartmentId);
      this.employeeForm.get('basicSalary').setValue(this.formatNumber.transform(data.basicSalary));
      this.employeeForm.get('rowVersion').setValue(data.rowVersion);
      this.elm.nativeElement.querySelector('#firstName').focus();

      if (data.avatar) {
        this.fileUrl = data.avatar.filePath;
      }
    }
  }
}
