import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommendationService } from '../commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class CommendationFormComponent implements OnInit {

  @Input() formAction = FormActionStatus.UnKnow;
  isSubmit = false;
  isLoading = false;
  form: FormGroup;

  constructor(private fb: FormBuilder, private commendationService: CommendationService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true]
    });
  }

  resetForm() {
    this.formAction = FormActionStatus.UnKnow;
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true]
    });
  }

  submitForm() {
    this.isSubmit = true;
    if (this.form.invalid) {
      return;
    }
    this.commendationService.save(this.form.value).subscribe((res: ResponseModel) => {
      if (res === null) {
        return;
      }
    });
    this.isLoading = true;
  }

}
