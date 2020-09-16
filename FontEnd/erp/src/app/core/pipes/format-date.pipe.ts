import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

import { FormatConstant } from '../constants/format.constant';

@Pipe({
  name: 'appDatePipe'
})
export class FormatDatePipe extends DatePipe implements PipeTransform {

  transform(value?: Date, ...args: unknown[]): string {
    if (value) {
      if (args !== null) {
      switch (args[0]) {
        case 'datetime':
          return super.transform(value, FormatConstant.datetime);
        }
      }
      return super.transform(value, FormatConstant.date);
    }
    return null;
  }

  parse(value: Date): string {
    if (value) {
      return super.transform(value, FormatConstant.date);
    }

    return null;
  }

}
