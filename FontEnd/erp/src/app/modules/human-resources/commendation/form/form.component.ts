import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommendationService } from '../commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class CommendationFormComponent implements OnInit {

  @Input() formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  commendationForm: FormGroup;

  constructor(private fb: FormBuilder, private commendationService: CommendationService) { }

  ngOnInit(): void {
    this.commendationForm = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true]
    });
  }

  resetForm() {
    this.formAction = FormActionStatus.UnKnow;
    this.commendationForm = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true]
    });
  }

  submitForm() {
    console.log(this.commendationForm.value);
    this.isSubmit = true;
    if (this.commendationForm.invalid) {
      return;
    }
    this.commendationService.save(this.commendationForm.value).subscribe((res: ResponseModel) => {
      if (res === null) {
        return;
      } else {
        if (res.responseStatus === ResponseStatus.success) {
          console.log('ok");');
        }
      }
    });
    this.isLoading = true;
  }

}
