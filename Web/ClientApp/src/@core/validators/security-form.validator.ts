import { FormGroup } from '@angular/forms';

export function SecurityFormValidator() {
	return (formGroup: FormGroup) => {
		const newPasswordControl = formGroup.controls['newPassword'];
		const newPasswordAgainControl = formGroup.controls['newPasswordAgain'];

		if (
			newPasswordControl.value != undefined &&
			newPasswordControl.value != '' &&
			(newPasswordAgainControl.value == '' || newPasswordAgainControl.value == undefined)
		) {
			newPasswordAgainControl.setErrors({ isRequired: true });
		} else {
			newPasswordAgainControl.setErrors(null);
		}

		if (newPasswordControl.value == undefined || newPasswordControl.value == '') {
			newPasswordControl.setErrors({ isRequired: true });
		}

		if (newPasswordAgainControl.errors && !newPasswordAgainControl.errors.mustMatch) {
			return;
		}

		if (newPasswordControl.value !== newPasswordAgainControl.value) {
			newPasswordAgainControl.setErrors({ mustMatch: true });
		} else {
			newPasswordAgainControl.setErrors(null);
		}
	};
}
