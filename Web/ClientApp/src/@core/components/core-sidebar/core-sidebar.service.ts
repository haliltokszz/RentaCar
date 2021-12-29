import { Injectable } from '@angular/core';
import { CoreSidebarComponent } from '@core/components/core-sidebar/core-sidebar.component';

@Injectable({
	providedIn: 'root',
})
export class CoreSidebarService {
	private _registry: { [key: string]: CoreSidebarComponent } = {};

	getSidebarRegistry(key): CoreSidebarComponent {
		if (!this._registry[key]) {
			console.warn(`The sidebar with the key '${key}' doesn't exist in the registry.`);
			return;
		}

		return this._registry[key];
	}

	setSidebarRegistry(key, sidebar): void {
		// Check if the key already being used
		if (this._registry[key]) {
			console.error(
				`The sidebar with the key '${key}' already exists. Either unregister it first or use a unique key.`,
			);

			return;
		}

		// Set to the registry
		this._registry[key] = sidebar;
	}

	removeSidebarRegistry(key): void {
		// Check if the sidebar registered
		if (!this._registry[key]) {
			console.warn(`The sidebar with the key '${key}' doesn't exist in the registry.`);
		}

		// Unregister the sidebar
		delete this._registry[key];
	}
}
