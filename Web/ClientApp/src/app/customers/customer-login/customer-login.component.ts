import {Component, OnInit} from "@angular/core";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: "app-customer-login",
  templateUrl: "./customer-login.component.html",
  styleUrls: ["./customer-login.component.css"]
})
export class CustomerLoginComponent implements OnInit {
  loginUser: any = {};

  constructor(private authService: AuthService) {
  }

  get isAuthenticated() {
    return this.authService.loggedIn();
  }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.loginUser, "Customer");
  }

  logOut() {
    this.authService.logOut();
  }
}
