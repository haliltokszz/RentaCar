import Swal, { SweetAlertIcon, SweetAlertInput, SweetAlertPosition, SweetAlertResult } from 'sweetalert2';

export abstract class Notification {
    public static printDeleteConfirmation = (
        position?: SweetAlertPosition,
    ): Promise<SweetAlertResult<any>> =>
        Swal.fire({
            title: 'Deletion',
            text: 'This operation can not be undone!',
            html: `<p><strong i18n> Are you sure you want to delete this record? </strong></p><p><strong></strong></p><p>All information associated to this record will be permanently deleted.</p><span class="text-danger">This operation can not be undone.</span>`,
            icon: 'warning',
            position: position || 'center',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!',
        });

    public static printQuestionModal = (title: string, text, icon: SweetAlertIcon, confirmText: string,
        position?: SweetAlertPosition, confirmButtonText?: string
    ): Promise<SweetAlertResult<any>> =>
        Swal.fire({
            title: title,
            text: text,
            html: `<p><strong></strong></p><p>${confirmText}</p>`,
            icon: icon || 'warning',
            position: position || 'center',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: confirmButtonText || 'Yes',
        });

    public static printSuccess = (
        message: string,
        position?: SweetAlertPosition,
        withButton?: boolean
    ): Promise<SweetAlertResult<any>> =>
        Swal.fire({
            position: position || 'center',
            icon: 'success',
            title: message,
            showConfirmButton: withButton || false,
            timer: withButton != undefined ? 0 : 1500,
        });

    public static printWarning = (
        message: string,
        position?: SweetAlertPosition,
        withButton?: boolean
    ): Promise<SweetAlertResult<any>> =>
        Swal.fire({
            position: position || 'center',
            icon: 'warning',
            title: message,
            showConfirmButton: withButton || false,
            timer: withButton != undefined ? 0 : 1500,
        });

    public static printInfo = (
        message: string,
        position?: SweetAlertPosition,
        withButton?: boolean
    ): Promise<SweetAlertResult<any>> =>
        Swal.fire({
            position: position || 'center',
            icon: 'info',
            title: message,
            showConfirmButton: withButton || false,
            timer: withButton != undefined ? 0 : 1500,
        });

    public static printError = (
        message: string,
        position?: SweetAlertPosition,
        withButton?: boolean,
        detail?: string,
    ): Promise<SweetAlertResult<any>> =>
        Swal.fire({
            position: position || 'center',
            icon: 'error',
            title: message,
            text: detail || '',
            showConfirmButton: withButton || false,
            timer: withButton != undefined ? 0 : 1500,
        });

    public static printCustomNotification = (options: {
        title?: string;
        text?: string;
        html?: string;
        input?: SweetAlertInput;
        preConfirm?: any;
        position?: SweetAlertPosition;
        imageUrl?: string;
        imageWidth?: string;
        imageHeight?: string;
        imageAlt?: string;
        showIcon?: boolean;
        icon?: SweetAlertIcon;
        backdrop?: string;
        titleClass?: string;
        showCancelButton?: boolean;
        cancelButtonText?: string;
        cancelButtonColor?: string;
        cancelButtonClass?: string;
        showDenyButton?: boolean;
        denyButtonText?: string;
        denyButtonColor?: string;
        denyButtonClass?: string;
        showConfirmButton?: boolean;
        confirmButtonClass?: string;
        confirmButtonText?: string;
        confirmButtonColor?: string;
        allowEnterKey?: boolean;
        allowOutsideClick?: boolean;
        allowEscapeKey?: boolean;
        focusCancel?: boolean;
        focusConfirm?: boolean;
        timer?: number;
        width?: string;
    }): Promise<SweetAlertResult<any>> => {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: options.confirmButtonClass || 'btn btn-success',
                cancelButton: options.cancelButtonClass || 'btn btn-danger',
                denyButton: options.denyButtonClass || 'btn btn-warning',
                title: options.titleClass,
            },
            buttonsStyling: false,
        });
        return swalWithBootstrapButtons.fire({
            title: options.title,
            text: options.text,
            html: options.html,
            input: options.input,
            preConfirm: options.preConfirm,
            showDenyButton: options.showDenyButton || false,
            showCancelButton: options.showCancelButton || false,
            showConfirmButton: options.showConfirmButton || false,
            confirmButtonText: options.confirmButtonText || `Save`,
            denyButtonText: options.denyButtonText || `Don't save`,
            cancelButtonText: options.cancelButtonText || `Cancel`,
            imageUrl: options.imageUrl,
            imageWidth: options.imageWidth,
            imageHeight: options.imageHeight,
            imageAlt: options.imageAlt,
            position: options.position || 'center',
            icon: options.showIcon && options.icon ? 'warning' : null,
            timer: options.timer,
            width: options.width,
            backdrop: options.backdrop || 'static',
            allowEnterKey: options.allowEnterKey,
            allowEscapeKey: options.allowEscapeKey,
            allowOutsideClick: options.allowOutsideClick,
            confirmButtonColor: options.confirmButtonColor,
            cancelButtonColor: options.cancelButtonColor,
            denyButtonColor: options.denyButtonColor,
            focusCancel: options.focusCancel,
            focusConfirm: options.focusConfirm,
        });
    };
}
