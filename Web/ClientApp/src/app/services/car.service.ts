import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Car } from "../models/car";
import { AlertifyService } from "./alertify.service";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root"
})
export class CarService {
  constructor(private httpClient: HttpClient,    
    private alertifyService:AlertifyService,
    private router:Router) {}
  path = "https://localhost:44394/api/car/";

  getCars(): Observable<Car[]> {
    return this.httpClient.get<Car[]>(this.path + "getall");
  }
  getCarsByCompany(companyId):Observable<Car[]>{
    return this.httpClient.get<Car[]>(this.path+"getbycompany/?companyId="+companyId)
  }

  getCarsByAvailable():Observable<Car[]>{
    return this.httpClient.get<Car[]>(this.path+"getbyavailable")
  }

 add(car){
  this.httpClient.post(this.path + 'add',car).subscribe(data=>{
    this.alertifyService.success("The car is added by succesfully")
    this.router.navigateByUrl('getall')
  });
 }
}
