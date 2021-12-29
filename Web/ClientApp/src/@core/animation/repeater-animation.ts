import { animate, style, transition, trigger } from '@angular/animations';

export const repeaterAnimation = trigger('heightIn', [
	transition(':enter', [
		style({ opacity: '0', height: '0px' }),
		animate('.2s ease-out', style({ opacity: '1', height: '*' })),
	]),
]);
