import { Component, OnInit } from "@angular/core";
import { AuthService } from "../../services/auth.service";

@Component({
  selector: "app-customer-login",
  templateUrl: "./customer-login.component.html",
  styleUrls: ["./customer-login.component.css"]
})
export class CustomerLoginComponent implements OnInit {
  constructor(private authService: AuthService) {}

  loginUser: any = {};

  ngOnInit() {}

  login() {
    this.authService.login(this.loginUser,"Customer");
  }

  logOut(){
    this.authService.logOut();
  }

  get isAuthenticated(){
     return this.authService.loggedIn();
  }
}
