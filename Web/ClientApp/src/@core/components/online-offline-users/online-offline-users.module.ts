import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreDirectivesModule } from '@core/directives/directives';
import { CoreSidebarModule } from '@core/components/core-sidebar/core-sidebar.module';

import {
	PerfectScrollbarConfigInterface,
	PerfectScrollbarModule,
	PERFECT_SCROLLBAR_CONFIG,
} from 'ngx-perfect-scrollbar';
import { OnlineOfflineUsersComponent } from './online-offline-users.component';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
	suppressScrollX: true,
	wheelPropagation: false,
};

@NgModule({
	declarations: [OnlineOfflineUsersComponent],
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		FlexLayoutModule,
		CoreDirectivesModule,
		CoreSidebarModule,
		PerfectScrollbarModule,
	],
	exports: [OnlineOfflineUsersComponent],
	providers: [
		{
			provide: PERFECT_SCROLLBAR_CONFIG,
			useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG,
		},
	],
})
export class OnlineOfflineUsersModule {}
