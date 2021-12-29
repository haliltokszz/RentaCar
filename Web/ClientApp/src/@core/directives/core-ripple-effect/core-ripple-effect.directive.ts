import { Directive, ElementRef, Input } from '@angular/core';

import * as Waves from 'node-waves';

@Directive({
	selector: '[rippleEffect]',
})
export class RippleEffectDirective {
	private _nativeElement: any;
	@Input() wave: string;
	constructor(private _elementRef: ElementRef) {}

	ngOnInit(): void {
		this._nativeElement = this._elementRef.nativeElement;

		if (
			!this._nativeElement.className.split(' ').some(function (c) {
				return /btn-outline-.*/.test(c);
			}) &&
			!this._nativeElement.className.split(' ').some(function (c) {
				return /btn-flat-.*/.test(c);
			})
		) {
			Waves.attach(this._nativeElement, ['waves-float', 'waves-light']);
		} else {
			Waves.attach(this._nativeElement);
		}
	}
}
