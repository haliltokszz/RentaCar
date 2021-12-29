import { Directive, ElementRef, HostListener, Output, EventEmitter } from '@angular/core';

@Directive({
    selector: '[outerClick]',
})
export class OuterClickDirective {
    constructor(private elementRef: ElementRef) { }

    @Output('onOutsideClick') onOutsideClick: EventEmitter<any> = new EventEmitter();

    @HostListener('document:click', ['$event.target'])
    public onClick(target) {
        const clickedInside = this.elementRef.nativeElement.contains(target);
        if (!clickedInside) {
            this.onOutsideClick.emit();
        }
    }
}
