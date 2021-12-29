import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {Car} from "../models/car";
import {CarService} from '../services/car.service';
import {RentalService} from '../services/rental.service';

@Component({
  selector: 'app-car-get',
  templateUrl: './car-get.component.html',
  providers: [CarService, RentalService]
})
export class GetCarsComponent {
  public cars: Car[];

  constructor(private carService: CarService,
              private rentalService: RentalService,
              private router: Router) {
  }

  ngOnInit() {
    this.getAll;
  }

  getAll() {
    this.carService.getCars().subscribe(data => {
      this.cars = data;
    });
  }

  getByAvailable() {
    this.carService.getCarsByAvailable().subscribe(data => {
      this.cars = data;
    });
  }

  goAddRental(carId: number) {
    this.router.navigateByUrl('/rental-add');
  }
}

