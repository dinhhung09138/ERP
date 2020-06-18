import { Validators, FormControl } from '@angular/forms';

/**
 * Custom validator for date time control
 */
export class DateValidator extends Validators {

  /**
   * Validate for DateTime picker control. Only check if year is over than 9999
   * @param control Form control element
   */
  static date(control: FormControl) {
    if (control.value) {
      if (control.value.getFullYear() < 1900 || control.value.getFullYear() > 9999) {
        return { date: true };
      }

    }

    return null;
  }
}
