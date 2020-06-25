import { Pipe, PipeTransform } from '@angular/core';

/**
 * Format number value
 */
@Pipe({
  name: 'appFormatNumber'
})
export class FormatNumberPipe implements PipeTransform {

  PADDING = '000000';

  THOUSANDS_SEPARATOR: string;
  DECIMAL_SEPARATOR: string;

  constructor() {
    this.THOUSANDS_SEPARATOR = ',';
    this.DECIMAL_SEPARATOR = '.';
  }

  transform(value: number | string, fractionSize: number = 0): string {

    if (value === null) {
      return '';
    }

    // Separate value into 2 sections based on DECIMAL_SEPARATOR
    let [integer, fraction = ''] = (value || '').toString().split(this.DECIMAL_SEPARATOR);

    fraction = fractionSize > 0 ? this.DECIMAL_SEPARATOR + (fraction + this.PADDING).substring(0, fractionSize) : '';

    integer = integer.replace(/\B(?=(\d{3})+(?!\d))/g, this.THOUSANDS_SEPARATOR);

    return integer + fraction;
  }

  parse(value: string | string, fractionSize: number = 0): string {

    if (value === null) {
      return '';
    }

    console.log(value);

    // Separate value into 2 sections based on DECIMAL_SEPARATOR
    let [integer, fraction = ''] = (value || '').split(this.DECIMAL_SEPARATOR);

    integer = integer.replace(new RegExp(this.THOUSANDS_SEPARATOR, 'g'), '');

    fraction = parseInt(fraction, 10) > 0 && fractionSize > 0
      ? this.DECIMAL_SEPARATOR + (fraction + this.PADDING).substring(0, fractionSize)
      : '';

    console.log(integer);
    console.log(fraction);

    return integer + fraction;
  }

}
