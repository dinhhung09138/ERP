import { Component, Input, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';

import { EmployeeViewModel } from '../../employee.model';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { PagingModel } from '../../../../../core/models/paging.model';
import { ModelOfStudyViewModel } from './../../../configuration/model-of-study/model-of-study.model';
import { RankingViewModel } from './../../../configuration/ranking/ranking.model';
import { RankingService } from './../../../configuration/ranking/ranking.service';
import { ModelOfStudyService } from './../../../configuration/model-of-study/model-of-study.service';
import { EmployeeEducationService } from './education.service';
import { EmployeeEducationFormComponent } from './form/form.component';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { ProfessionalQualificationService } from '../../../configuration/professional-qualification/professional-qualification.service';
import { SchoolService } from './../../../configuration/school/school.service';
import { MajorService } from './../../../configuration/major/major.service';
import { MajorViewModel } from './../../../configuration/major/major.model';
import { SchoolViewModel } from './../../../configuration/school/school.model';
import { EducationViewModel } from './../../../configuration/education/education.model';

@Component({
  selector: 'app-hr-employee-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss']
})
export class EmployeeEducationComponent implements OnInit {

  @Input() employee: EmployeeViewModel;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;
  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = [ 'school',
                              'educationTypeName',
                              'majorName',
                              'rankingName',
                              'modelOfStudyName',
                              'year',
                              'action' ];
  dataSource = new MatTableDataSource();
  listEducation: EducationViewModel[];
  listRank: RankingViewModel[];
  listModelOfStudy: ModelOfStudyViewModel[];
  listSchool: SchoolViewModel[];
  listMajor: MajorViewModel[];

  constructor(
    private dialog: MatDialog,
    private employeeEducationService: EmployeeEducationService,
    private educationTypeService: ProfessionalQualificationService,
    private modelOfStudyService: ModelOfStudyService,
    private rankingService: RankingService,
    private majorService: MajorService,
    private schoolService: SchoolService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeEducationService.getPermission();
    this.dataSource.sort = this.sort;
  }

  onAddClick() {
    if (this.permission.allowInsert === false) {
      return;
    }
    this.showFormModal();
  }

  onUpdateClick(id: number) {
    if (this.permission.allowUpdate === false) {
      return;
    }
    this.showFormModal(id);
  }

  onDeleteClick(id: number, version: any) {
    this.employeeEducationService.confirmDelete(id, version).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.getList();
      }
    });
  }

  onPageChange(page: PageEvent) {
    this.paging.pageSize = page.pageSize;
    this.paging.pageIndex = page.pageIndex;

    if (page.pageSize !== this.currentPageSize) {
      this.currentPageSize = page.pageSize;
      this.paging.pageIndex = 0;
    }
    this.getList();
  }

  public getList() {
    if (this.employee === undefined) {
      return;
    }
    this.isLoading = true;
    this.employeeEducationService.getList(this.paging, this.searchText, this.employee.id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.TotalItems;
      }
      this.isLoading = false;
    });
  }

  public getRanking() {
    this.isLoading = true;
    this.rankingService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listRank = response.result;
      }
      this.isLoading = false;
    });
  }

  public getModelOfStudyType() {
    this.isLoading = true;
    this.modelOfStudyService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listModelOfStudy = response.result;
      }
      this.isLoading = false;
    });
  }

  public getEducationType() {
    this.isLoading = true;
    this.educationTypeService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listEducation = response.result;
      }
      this.isLoading = false;
    });
  }

  public getMajor() {
    this.isLoading = true;
    this.majorService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listMajor = response.result;
      }
      this.isLoading = false;
    });
  }

  public getSchool() {
    this.isLoading = true;
    this.schoolService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listSchool = response.result;
      }
      this.isLoading = false;
    });
  }

  private showFormModal(id?: number) {
    const modalRef = this.dialog.open(EmployeeEducationFormComponent, {
      disableClose: true,
      panelClass: 'mat-modal-md',
      data: {
        isPopup: true,
        itemId: id,
        employeeId: this.employee.id,
        listEducation: this.listEducation,
        listRank: this.listRank,
        listModelOfStudy: this.listModelOfStudy,
        listMajor: this.listMajor,
        listSchool: this.listSchool,
      }
    });

    return modalRef.afterClosed().subscribe(
      (result: boolean) => {
        if (result === true) {
          this.getList();
        }
      }
    );
  }

}
