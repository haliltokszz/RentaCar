import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {AlertifyService} from "./alertify.service";
import {Router} from "@angular/router";
import {Rentals} from "../models/rental";

@Injectable({
  providedIn: "root"
})
export class RentalService {
  path = "https://localhost:44394/api/rental/";

  constructor(private httpClient: HttpClient,
              private alertifyService: AlertifyService,
              private router: Router) {
  }

  getAllRentals(): Observable<Rentals[]> {
    return this.httpClient.get<Rentals[]>(this.path + "getall");
  }

  getRentalsByCompany(companyId): Observable<Rentals[]> {
    return this.httpClient.get<Rentals[]>(this.path + "getbycompany/?companyId=" + companyId)
  }

  getRentalsByCustomer(customerId): Observable<Rentals[]> {
    return this.httpClient.get<Rentals[]>(this.path + "getbycompany/?customerId=" + customerId)
  }

  getRentalsByCar(carId): Observable<Rentals[]> {
    return this.httpClient.get<Rentals[]>(this.path + "getbycompany/?carId=" + carId)
  }

  getRentalsByApprove(): Observable<Rentals[]> {
    return this.httpClient.get<Rentals[]>(this.path + "getbynoapprove")
  }

  add(rental) {
    this.httpClient.post(this.path + 'add', rental).subscribe(data => {
      this.alertifyService.success("The rental is added by succesfully")
      this.router.navigateByUrl('/car-get')
    });
  }
}
