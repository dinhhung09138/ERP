import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appPrecedence]'
})
export class PrecedenceDirective {

  constructor(private elm: ElementRef) { }

  @Input() IsPrecedence: boolean;

  @HostListener('keydown', ['$event']) onKeydown(event: KeyboardEvent) {

    if (['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'Backspace', 'Delete', 'Enter', 'Tab'].indexOf(event.key) !== -1) {
      return;
    }

    event.preventDefault();
  }

}
