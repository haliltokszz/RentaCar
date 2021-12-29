import {Component, OnInit} from "@angular/core";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CarService} from "src/app/services/car.service";
import {Car} from "src/app/models/car";


@Component({
  selector: "app-car-add",
  templateUrl: "./car-add.component.html",
  styleUrls: ["./car-add.component.css"],
  providers: [CarService]
})
export class CarAddComponent implements OnInit {
  car: Car;
  carAddForm: FormGroup;

  constructor(
    private carService: CarService,
    private formBuilder: FormBuilder
  ) {
  }

  createCityForm() {
    this.carAddForm = this.formBuilder.group({
      name: ["", Validators.required],
      description: ["", Validators.required]
    });
  }

  ngOnInit() {
    this.createCityForm();
  }

  add() {
    if (this.carAddForm.valid) {
      this.car = Object.assign({}, this.carAddForm.value)
      //Todo
      this.carService.add(this.car);
    }
  }
}
