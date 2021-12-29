import { Injectable } from '@angular/core';

import { TranslateService } from '@ngx-translate/core';

export interface Locale {
	lang: string;
	data: Object;
}

@Injectable({
	providedIn: 'root',
})
export class CoreTranslationService {
	constructor(private _translateService: TranslateService) {}

	translate(...args: Locale[]): void {
		const locales = [...args];

		locales.forEach((locale) => {
			// use setTranslation() with the third argument value as true to append translations instead of replacing them
			this._translateService.setTranslation(locale.lang, locale.data, true);
		});
	}
}
