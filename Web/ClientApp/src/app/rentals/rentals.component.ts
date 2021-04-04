import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Rentals } from '../models/rental';
import { RentalService } from '../services/rental.service';

@Component({
  selector: 'app-rentals',
  templateUrl: './rentals.component.html',
  styleUrls: ['./rentals.component.css'],
  providers: [RentalService]
})
export class RentalsComponent implements OnInit {
  public rentals: Rentals[];
  public apiPath: string;
  public selectPath(path: string) {
    this.apiPath = path;
  }
  constructor(private rentalService: RentalService) {}

  ngOnInit() {
    this.getAll();
  }

  getAll(){
    this.rentalService.getAllRentals().subscribe(data => {
      this.rentals = data;
    });
  }

  getApprove(){
    this.rentalService.getRentalsByApprove().subscribe(data => {
      this.rentals = data;
    });
  }

}
