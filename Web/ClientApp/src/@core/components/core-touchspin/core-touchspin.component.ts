import { FormGroup } from '@angular/forms';
import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';

@Component({
	selector: 'core-touchspin',
	templateUrl: './core-touchspin.component.html',
	styleUrls: ['./core-touchspin.component.scss'],
	encapsulation: ViewEncapsulation.None,
})
export class CoreTouchspinComponent implements OnInit {
	@Input('numberValue') numberValue = 0;
	@Input('controlName') controlName: string = '';
	@Input('iconChevron') iconChevron = false;
	@Input('disable') disabledValue = false;
	@Input('size') size: string = '';
	@Input('color') color: string = '';
	@Input('stepValue') stepValue: number;
	@Input('maxValue') maxValue: number = 9999;
	@Input('minValue') minValue: number = 0;
	@Input('fGroup') formGroup: FormGroup;

	public disabledValueIncrement = false;
	public disabledValueDecrement = false;

	constructor() {}

	inputChange(inputValue: number) {
		if (inputValue == this.maxValue || inputValue > this.maxValue) {
			this.disabledValueIncrement = true;
		} else {
			this.disabledValueIncrement = false;
		}
		if (inputValue == this.minValue || inputValue < this.minValue) {
			this.disabledValueDecrement = true;
		} else {
			this.disabledValueDecrement = false;
		}
	}

	increment() {
		if (this.stepValue == undefined) {
			this.numberValue += 1;
		} else {
			this.numberValue += this.stepValue;
		}

		if (!(this.minValue == undefined || this.maxValue == undefined)) {
			if (this.numberValue == this.maxValue || this.numberValue > this.maxValue) {
				this.disabledValueIncrement = true;
			} else {
				this.disabledValueIncrement = false;
			}
			if (this.numberValue > this.minValue) {
				this.disabledValueDecrement = false;
			} else {
				this.disabledValueDecrement = true;
			}
		}
	}

	decrement() {
		if (this.stepValue == undefined) {
			this.numberValue -= 1;
		} else {
			this.numberValue -= this.stepValue;
		}

		if (!(this.minValue == undefined || this.maxValue == undefined)) {
			if (this.numberValue == this.minValue || this.numberValue < this.minValue) {
				this.disabledValueDecrement = true;
			} else {
				this.disabledValueDecrement = false;
			}
			if (this.numberValue < this.maxValue) {
				this.disabledValueIncrement = false;
			} else {
				this.disabledValueIncrement = true;
			}
		}
	}

	ngOnInit(): void {
		this.disabledValueIncrement = this.disabledValue;
		this.disabledValueDecrement = this.disabledValue;
	}
}
