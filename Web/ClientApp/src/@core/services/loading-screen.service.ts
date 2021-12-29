import { Inject, Injectable } from '@angular/core';
import { DOCUMENT } from '@angular/common';

import { animate, AnimationBuilder, AnimationPlayer, style } from '@angular/animations';
import { NavigationEnd, Router } from '@angular/router';

import { filter, take } from 'rxjs/operators';

@Injectable({
	providedIn: 'root',
})
export class CoreLoadingScreenService {
	loadingScreenEl: any;
	animationPlayer: AnimationPlayer;

	constructor(
		@Inject(DOCUMENT) private _document: any,
		private _router: Router,
		private _animationBuilder: AnimationBuilder,
	) {
		this._init();
	}

	private _init(): void {
		this.loadingScreenEl = this._document.body.querySelector('#loading-bg');

		if (this.loadingScreenEl) {
			this._router.events
				.pipe(
					filter((event) => event instanceof NavigationEnd),
					take(1),
				)
				.subscribe(() => {
					setTimeout(() => {
						this.hide();
					});
				});
		}
	}

	show(): void {
		this.animationPlayer = this._animationBuilder
			.build([
				style({
					opacity: '0',
					zIndex: '99999',
				}),
				animate('250ms ease', style({ opacity: '1' })),
			])
			.create(this.loadingScreenEl);

		setTimeout(() => {
			this.animationPlayer.play();
		}, 0);
	}

	hide(): void {
		this.animationPlayer = this._animationBuilder
			.build([
				style({ opacity: '1' }),
				animate(
					'250ms ease',
					style({
						opacity: '0',
						zIndex: '-10',
					}),
				),
			])
			.create(this.loadingScreenEl);

		setTimeout(() => {
			// this.loadingScreenEl.remove();
			this.animationPlayer.play();
		}, 0);
	}
}
