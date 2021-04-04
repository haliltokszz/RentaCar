import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Rentals } from 'src/app/models/rental';
import { RentalService } from '../services/rental.service';

@Component({
  selector: 'app-car-get',
  templateUrl: './car-get.component.html',
  providers: [RentalService]
})
export class GetCarsComponent {
  public rental: Rentals;

  constructor(
    private rentalService: RentalService,
    private router: Router) {}
  ngOnInit() {
    
  }
}

