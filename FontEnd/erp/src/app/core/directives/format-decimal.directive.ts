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

