import { Injectable } from "@angular/core";
import { LoginUser } from "../models/loginUser";
import { HttpHeaders, HttpClient} from "@angular/common/http";
import { JwtHelperService } from "@auth0/angular-jwt";
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from "@angular/router";
import { AlertifyService } from "./alertify.service";
import { RegisterUser } from "../models/registerUser";
import { RegisterEmployee } from "../models/registerEmployee";

@Injectable({
  providedIn: "root"
})
export class AuthService {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private alertifyService: AlertifyService
  ) {}
  path = "https://localhost:44394/api";
  userToken: any;
  decodedToken: any;
  jwtHelper: JwtHelperService = new JwtHelperService();
  TOKEN_KEY="token"

  login(loginUser: LoginUser, userType:string) {
    let headers = new HttpHeaders();
    let navigateUrl : string;
    if(userType == "Customer") {
      this.path +="customer";
      navigateUrl = "/car-get";
    }
    else{
      this.path += "employee";
      navigateUrl = "rental-get";
    } 
    headers = headers.append("Content-Type", "application/json");
    this.httpClient
      .post(this.path + "/login", loginUser, { headers: headers })
      .subscribe(data => {
        this.saveToken(data);
        this.userToken = data;
        this.decodedToken = this.jwtHelper.decodeToken(data.toString());
        this.alertifyService.success("Successful login to the system.");
        this.router.navigateByUrl(navigateUrl);
      });
  }

  registerCustomer(registerUser: RegisterUser) {
    let headers = new HttpHeaders();
    headers = headers.append("Content-Type", "application/json");
    this.httpClient
      .post(this.path + "/customer/register", registerUser, { headers: headers })
      .subscribe(data=>{
        this.router.navigateByUrl("/customer-login");
      });
  }

  registerEmployee(registerEmployee: RegisterEmployee) {
    let headers = new HttpHeaders();
    headers = headers.append("Content-Type", "application/json");
    this.httpClient
      .post(this.path + "/employee/register", registerEmployee, { headers: headers })
      .subscribe(data=>{
        
      });
  }

  saveToken(token) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  logOut(){
    localStorage.removeItem(this.TOKEN_KEY)
    this.alertifyService.error("Logged out of the system.");
  }

  loggedIn(){
    return this.jwtHelper.isTokenExpired(this.TOKEN_KEY)
  }

  get token(){
    return localStorage.getItem(this.TOKEN_KEY);
  }

 
  getCurrentUserId(){
    return this.jwtHelper.decodeToken(this.token).nameid
  }



}
