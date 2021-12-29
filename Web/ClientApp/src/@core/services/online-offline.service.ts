import { Injectable } from '@angular/core';
import { TokenResponse } from 'app/auth/models';
import { Observable, Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class OnlineOfflineService {
	public onlineUsers$: Observable<TokenResponse[]>;
	private onlineUsersSubject$: Subject<TokenResponse[]>;

	constructor() {
		this.onlineUsersSubject$ = new Subject<TokenResponse[]>();
		this.onlineUsers$ = this.onlineUsersSubject$.asObservable();
	}

	updateOnlineUsers(onlineUsers: TokenResponse[]) {
		this.onlineUsersSubject$.next(onlineUsers);
	}
}
