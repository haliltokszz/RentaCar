import { OnlyNumber } from './only-number.directive';
import { ValidatorDirective } from './validator.directive';
import { NgModule } from '@angular/core';

import { FeatherIconDirective } from '@core/directives/core-feather-icons/core-feather-icons';
import { RippleEffectDirective } from '@core/directives/core-ripple-effect/core-ripple-effect.directive';
import { OuterClickDirective } from './outerclick.directive';

@NgModule({
	declarations: [
		RippleEffectDirective,
		FeatherIconDirective,
		OuterClickDirective,
		ValidatorDirective,
		OnlyNumber,
	],
	exports: [
		RippleEffectDirective,
		FeatherIconDirective,
		OuterClickDirective,
		ValidatorDirective,
		OnlyNumber,
	],
})
export class CoreDirectivesModule {}
