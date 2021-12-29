import { Component, OnInit, Input, ViewChild, ElementRef, HostListener } from '@angular/core';

import { CoreBlockUiComponent } from '@core/components/core-card/core-block-ui/core-block-ui.component';
import { CoreSidebarService } from '../core-sidebar/core-sidebar.service';
import { EventEmitter } from '@angular/core';
import { Output } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'core-card',
	templateUrl: './core-card.component.html',
})
export class CoreCardComponent implements OnInit {
	@Output() addEvent = new EventEmitter();
	// public
	// Generate random string  assign to specific core-card to only block that specific card
	public coreCardId: string = Math.random().toString(36).substring(2);

	// To pass core-block-ui component values to _CoreBlockUiComponent variable
	public _CoreBlockUiComponent = CoreBlockUiComponent;

	// default status before click event
	public onclickEvent = {
		collapseStatus: false,
		expandStatus: false,
		reloadStatus: false,
		closeStatus: false,
		filterStatus: false,
		addStatus: false,
	};

	// default action-views
	public actionsView = {
		collapse: false,
		expand: false,
		reload: false,
		close: false,
		filter: false,
		add: false,
	};

	@Input() actions: string[];
	@Input() sidebarKey: string;
	@Input() addPageUrl: string = '';
	@HostListener('document:keydown.escape', ['$event']) onKeydownHandler(event: KeyboardEvent) {
		// on press of esc card will return to normal from full screen
		if (this.onclickEvent.expandStatus) {
			this.onclickEvent.expandStatus = false;
		}
	}

	// private
	@ViewChild('coreCard') private coreCard: ElementRef;
	@ViewChild('cardHeader') private cardHeader: ElementRef;

	constructor(private _coreSidebarService: CoreSidebarService, private router: Router) { }

	// Lifecycle Hooks
	// -----------------------------------------------------------------------------------------------------

	ngOnInit() {
		// show collapse icon if actions includes 'collapse'
		if (this.actions.includes('collapse')) {
			this.actionsView.collapse = true;
		}

		// show expand icon if actions includes 'expand'
		if (this.actions.includes('expand')) {
			this.actionsView.expand = true;
		}

		// show reload icon if actions includes 'reload'
		if (this.actions.includes('reload')) {
			this.actionsView.reload = true;
		}

		// show close icon if actions includes 'close'
		if (this.actions.includes('close')) {
			this.actionsView.close = true;
		}

		//filter sidebar
		if (this.actions.includes('filter')) {
			this.actionsView.filter = true;
		}

		//add
		if (this.actions.includes('add')) {
			this.actionsView.add = true;
		}
	}

	// Public Methods
	// -----------------------------------------------------------------------------------------------------

	collapse() {
		const cardHeaderEl = this.cardHeader.nativeElement;
		this.onclickEvent.collapseStatus = !this.onclickEvent.collapseStatus;
		if (this.onclickEvent.collapseStatus) {
			setTimeout(() => {
				cardHeaderEl.classList.add('pb-2');
			}, 350);
		} else {
			cardHeaderEl.classList.remove('pb-2');
		}
	}

	close() {
		this.coreCard.nativeElement.remove();
	}

	filter() {
		this._coreSidebarService.getSidebarRegistry(this.sidebarKey).toggleOpen();
	}

	reload() { }

	navigate(path) {
		this.router.navigate([path]);
	}
}
