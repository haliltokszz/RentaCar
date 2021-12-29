import { TranslateService } from '@ngx-translate/core';
import { Injectable } from '@angular/core';
import { ProgressAnimationType, ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class ToastService {
	// ########### Default Settings #########
	settings = new ToastSettings({});
	// ##############################

	constructor(private toaster: ToastrService, protected translate: TranslateService) {}

	/**
	 * Show succes toast
	 * @param msg
	 * @param title
	 * @param settings
	 */
	success(msg, title, settings?: ToastSettings): void {
		this.toaster.success(msg, title, settings ?? this.settings);
	}

	/**
	 * Show warning toast
	 * @param msg
	 * @param title
	 * @param settings
	 */
	warning(msg, title, settings?: ToastSettings): void {
		this.toaster.warning(msg, title, settings ?? this.settings);
	}

	/**
	 * Show error toast
	 * @param msg
	 * @param title
	 * @param settings
	 */
	error(msg, title, settings?: ToastSettings): void {
		this.toaster.error(msg, title, settings ?? this.settings);
	}
	/**
	 * Show info toast
	 * @param msg
	 * @param title
	 * @param settings
	 */
	info(msg, title, settings?: ToastSettings): void {
		this.toaster.info(msg, title, settings ?? this.settings);
	}

	/**
	 * Handles error message, shows the message if exists else;
	 *
	 * Renders just 'Error' message.
	 * @param error
	 * @param settings
	 */
	handleError(error, settings?: ToastSettings) {
		this.toaster.error(
			error && error.error && error.error.message
				? error.error.message
				: this.translate.instant('alerts.error'),
			this.translate.instant('alerts.error'),
			settings ?? this.settings,
		);
	}
	/**
	 * Clear all or specific toast message.
	 * @param toastId
	 */
	clearToasts = (toastId?: number): void => {
		if (toastId) this.toaster.clear(toastId);
		this.toaster.clear();
	};
}

export class ToastSettings {
	progressBar?: boolean;
	progressAnimation?: ProgressAnimationType;
	closeButton?: boolean;
	enableHtml?: boolean;
	positionClass?: PositionClass;
	toastClass?: string;

	constructor(
		options: {
			progressBar?: boolean;
			progressAnimation?: ProgressAnimationType;
			closeButton?: boolean;
			enableHtml?: boolean;
			positionClass?: PositionClass;
			toastClass?: string;
		} = {},
	) {
		this.progressBar = options.progressBar ?? true;
		this.progressAnimation = options.progressAnimation ?? 'decreasing';
		this.closeButton = options.closeButton ?? true;
		this.enableHtml = options.enableHtml ?? true;
		this.toastClass = options.toastClass ?? 'toast ngx-toastr';
		this.positionClass = options.positionClass ?? 'toast-top-right';
	}
}

export declare type PositionClass =
	| 'toast-top-center'
	| 'toast-center-center'
	| 'toast-bottom-center'
	| 'toast-top-full-width'
	| 'toast-bottom-full-width'
	| 'toast-top-left'
	| 'toast-top-right'
	| 'toast-bottom-right'
	| 'toast-bottom-left'
	| 'toast-top-right';
