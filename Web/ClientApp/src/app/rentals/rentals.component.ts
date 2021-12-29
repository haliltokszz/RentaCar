import {Component, OnInit} from '@angular/core';
import {Rentals} from '../models/rental';
import {RentalService} from '../services/rental.service';

@Component({
  selector: 'app-rentals',
  templateUrl: './rentals.component.html',
  styleUrls: ['./rentals.component.css'],
  providers: [RentalService]
})
export class RentalsComponent implements OnInit {
  public rentals: Rentals[];
  public apiPath: string;

  constructor(private rentalService: RentalService) {
  }

  public selectPath(path: string) {
    this.apiPath = path;
  }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.rentalService.getAllRentals().subscribe(data => {
      this.rentals = data;
    });
  }

  getApprove() {
    this.rentalService.getRentalsByApprove().subscribe(data => {
      this.rentals = data;
    });
  }

}
