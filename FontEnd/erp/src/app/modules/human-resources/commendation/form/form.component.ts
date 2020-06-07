import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommendationService } from '../commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class CommendationFormComponent implements OnInit {

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

  submit() {
    this.isSubmit = true;
    if (this.form.invalid) {
      return;
    }
    this.commendationService.save(this.form.value).subscribe((res: ResponseModel) => {
      if (res === null) {
        return;
      }
    });
    console.log(this.form.value);
    this.isLoading = true;
  }

}
