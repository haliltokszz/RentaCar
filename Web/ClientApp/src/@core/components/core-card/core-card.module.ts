import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CoreCommonModule } from '@core/common.module';
import { CoreCardComponent } from '@core/components/core-card/core-card.component';
import { CoreBlockUiComponent } from '@core/components/core-card/core-block-ui/core-block-ui.component';
import { CoreDirectivesModule } from '@core/directives/directives';

@NgModule({
	declarations: [CoreCardComponent, CoreBlockUiComponent],
	imports: [CommonModule, NgbModule, CoreCommonModule, CoreDirectivesModule],
	exports: [CoreCardComponent],
	entryComponents: [
		CoreBlockUiComponent, // Make sure to add ng-block-ui custom block component to the entry components
	],
})
export class CoreCardModule { }
