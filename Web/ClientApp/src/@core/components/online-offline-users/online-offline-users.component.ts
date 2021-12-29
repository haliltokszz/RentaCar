import { Component, OnInit, OnDestroy, ViewEncapsulation } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { CoreSidebarService } from '@core/components/core-sidebar/core-sidebar.service';
import { OnlineOfflineService } from '@core/services/online-offline.service';
import { TokenResponse } from 'app/auth/models';

@Component({
	selector: 'core-theme-customizer',
	templateUrl: './online-offline-users.component.html',
	styleUrls: ['./online-offline-users.component.scss'],
	encapsulation: ViewEncapsulation.None,
})
export class OnlineOfflineUsersComponent implements OnInit, OnDestroy {
	public offlineUsers;
	public onlineUsers: TokenResponse[] = [];
	private _unsubscribeAll: Subject<any>;
	constructor(
		private _coreSidebarService: CoreSidebarService,
		private onlineOfflineService: OnlineOfflineService,
	) {
		// Set the private defaults
		this._unsubscribeAll = new Subject();
	}

	ngOnInit(): void {
		this.onlineOfflineService.onlineUsers$.subscribe((res) => (this.onlineUsers = res));
		this.offlineUsers = [];
	}

	ngOnDestroy(): void {
		this._unsubscribeAll.next();
		this._unsubscribeAll.complete();
	}

	toggleSidebar(key): void {
		this._coreSidebarService.getSidebarRegistry(key).toggleOpen();
	}
}
