import { DatePipe } from '@angular/common';
import { Injectable } from '@angular/core';

import { NativeDateAdapter, MatDateFormats } from '@angular/material/core';

import { FormatConstant } from '../constants/format.constant';

/**
 * Use for format datetime picker
 */
@Injectable()
export class AppDateAdapter extends NativeDateAdapter {
  format(date: Date, displayFormat: object): string {

    return new DatePipe('en-US').transform(date, FormatConstant.date);
  }
}

export const APP_DATE_FORMATS: MatDateFormats = {
  parse: {
    dateInput: { month: 'short', year: 'numeric', day: 'numeric' },
  },
  display: {
    dateInput: 'input',
    monthYearLabel: { year: 'numeric', month: 'numeric' },
    dateA11yLabel: { year: 'numeric', month: 'long', day: 'numeric' },
    monthYearA11yLabel: { year: 'numeric', month: 'long' }
  }
};
