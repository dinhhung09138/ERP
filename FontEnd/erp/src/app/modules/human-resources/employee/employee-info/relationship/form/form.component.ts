import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeeRelationShipService } from '../relationship.service';
import { RelationshipTypeService } from '../../../../configuration/relationship-type/relationship-type.service';
import { RelationshipTypeViewModel } from '../../../../configuration/relationship-type/relationship-type.model';
import { ResponseModel } from '../../../../../../core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { EmployeeRelationShipViewModel } from '../relationship.model';
import { AppValidator } from '../../../../../../core/validators/app.validator';
import { FormActionStatus } from '../../../../../../core/enums/form-action-status.enum';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogDataInterface } from '../../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeRelationshipFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, { static: true}) formDirective: FormGroupDirective;

  formTitle = '';
  isLoading = false;
  isSubmit = false;
  form: FormGroup;
  formAction: FormActionStatus;
  listRelationShip: RelationshipTypeViewModel[];
  item: EmployeeRelationShipViewModel;

  constructor(
    private elm: ElementRef,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<EmployeeRelationshipFormComponent>,
    private fb: FormBuilder,
    private emplRelationShipService: EmployeeRelationShipService,
  ) { }

  ngOnInit(): void {

    this.form = this.fb.group({
      id: [0],
      fullName: ['', [Validators.required]],
      address: ['', [Validators.maxLength(255)]],
      mobile: ['', [Validators.maxLength(20)]],
      relationshipTypeId: [null, [Validators.required]],
      isActive: [true],
      rowVersion: [null]
    });

    if (this.dialogData && this.dialogData.isPopup === true) {
      this.listRelationShip = this.dialogData.data;
    }
  }

  onSubmit() {

  }

}
