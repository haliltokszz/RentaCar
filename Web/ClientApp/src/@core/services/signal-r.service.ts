import { Injectable, Injector } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { AuthenticationService } from 'app/auth/service';
import { environment } from 'environments/environment';
import { LogLevel } from '@microsoft/signalr';
import * as _ from 'lodash';
import { TokenResponse } from 'app/auth/models';
import { OnlineOfflineService } from './online-offline.service';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class SignalRService {
	public hubConnection: HubConnection;
	public adminServiceHubConnection: HubConnection;
	public currentUser: TokenResponse;
	constructor(
		private onlineOfflineService: OnlineOfflineService,
		private injector: Injector,
		private router: Router,
	) {}

	startConnection() {
		this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
		this.createSignalRConnection();
		this.createAdminServiceSignalRConnection();
		this.listenOnlineOfflineUsers();
		this.maintenanceMode();
	}

	connect = (url: string): HubConnection => {
		const response = new HubConnectionBuilder()
			.withUrl(url, {
				accessTokenFactory: () => this.currentUser.token,
				logger: environment.apiUrl ? LogLevel.Critical : LogLevel.Trace,
			})
			.withAutomaticReconnect()
			.build();

		return response;
	};

	createSignalRConnection = (): void => {
		// this.hubConnection = this.connect('http://localhost:9001/onlineOfflineHub');
		this.hubConnection = new HubConnectionBuilder()
			.withUrl(`${environment.apiUrl}/signalr-service/onlineOfflineHub`)
			.build();

		this.hubConnection.start();
	};

	createAdminServiceSignalRConnection = (): void => {
		this.adminServiceHubConnection = this.connect(`${environment.apiUrl}/SystemHub`);
		this.adminServiceHubConnection.start();
	};

	listenOnlineOfflineUsers() {
		this.hubConnection.on('SetConnectionId', (res) => {
			if (this.currentUser) {
				this.hubConnection.invoke('AddUserlist', this.currentUser.name, res, this.currentUser.role);
			}
		});

		this.hubConnection.on('UpdateOnlineOfflineUsers', (res) => {
			this.onlineOfflineService.updateOnlineUsers(res);
		});
		this.hubConnection.on('RemoveOnlineOfflineUsers', (res) => {
			this.onlineOfflineService.updateOnlineUsers(res);
		});
	}

	maintenanceMode() {
		this.adminServiceHubConnection.on('CommonUserGroupMethod', (res) => {
			const auth = this.injector.get(AuthenticationService);
			auth.logout();
			this.router.navigate(['/pages/authentication/login'], {});
		});
	}

	stopConnection() {
		if (this.hubConnection) {
			this.hubConnection.stop();
		}
	}
}
