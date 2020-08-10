import { Directive, ElementRef, OnInit, HostListener } from '@angular/core';
import { FormatNumberPipe } from '../pipes/format-number.pipe';

@Directive({
  selector: '[appFormatDecimal]',
  host: {
    'class': 'text-right',
  }
})
export class FormatDecimalDirective implements OnInit {

  private elm: HTMLInputElement;

  constructor(
    private elementRef: ElementRef,
    private formatNumberPipe: FormatNumberPipe,
  ) {
    this.elm = this.elementRef.nativeElement;
  }

  ngOnInit() {

  }

  @HostListener('keydown', ['$event']) onKeydown(event: KeyboardEvent) {

    if (['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'Backspace', 'Delete', 'Enter', 'Tab'].indexOf(event.key) !== -1) {
      return;
    }

    event.preventDefault();
  }

  @HostListener('focus', ['$event.target.value'])
  onFocus(value) {
    if (value) {
      this.elm.value = this.formatNumberPipe.parse(value, 0);
    }
  }

  @HostListener('blur', ['$event.target.value'])
  onBlur(value) {
    if (value) {
      this.elm.value = this.formatNumberPipe.transform(value, 0);
    }
  }

}

