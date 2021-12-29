import { FormControl } from '@angular/forms';
import { Directive, ElementRef, Input, Renderer2, OnInit } from '@angular/core';

@Directive({
	selector: '[validationMsg]',
})
export class ValidatorDirective implements OnInit {
	@Input() fControl: FormControl;
	constructor(private renderer: Renderer2, private hostElement: ElementRef) {}

	ngOnInit() {
		if (this.fControl.errors != null && this.fControl.touched) {
			this.renderer.addClass(this.hostElement.nativeElement, 'error');
		}
	}
}
