import { Validators, FormControl } from '@angular/forms';
import { isNumber } from 'util';
import { FormatNumberPipe } from '../pipes/format-number.pipe';

/**
 * Custom validator for date time control
 */
export class AppValidator extends Validators {

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

  static money(control: FormControl) {
    if (control.value) {
      const numberFormat = new FormatNumberPipe();
      const value = numberFormat.parse(control.value.toString());
      const result = Number(value);
      if (isNaN(result)) {
        return { money: true };
      }

      return null;
    }

    return null;
  }

  static number(control: FormControl) {
    if (control.value) {
      const numberFormat = new FormatNumberPipe();
      const value = numberFormat.parse(control.value.toString());
      const result = Number(value);

      if (isNaN(result)) {
        return { number: true };
      }
    }

    return null;
  }
}
