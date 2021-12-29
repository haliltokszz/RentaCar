import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CoreCommonModule } from '@core/common.module';
import { CoreCardSnippetComponent } from '@core/components/card-snippet/card-snippet.component';

@NgModule({
	declarations: [CoreCardSnippetComponent],
	imports: [CommonModule, NgbModule, CoreCommonModule],

	exports: [CoreCardSnippetComponent],
})
export class CardSnippetModule {}
