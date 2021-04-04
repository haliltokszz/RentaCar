import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule } from "@auth0/angular-jwt";
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { GetCarsComponent } from './cars/car-get.component';
import { RentalsComponent } from './rentals/rentals.component';
import { AlertifyService } from './services/alertify.service';
import { RegisterComponent } from './customers/customer-register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { CustomerLoginComponent } from './customers/customer-login/customer-login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GetCarsComponent,
    RentalsComponent,
    RegisterComponent,
    CustomerLoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    JwtModule,
    MatInputModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'car-get', component: GetCarsComponent },
      { path: 'rental-get', component: RentalsComponent },
      { path: 'customer-register', component: RegisterComponent },
      { path: 'customer-login', component: CustomerLoginComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [AlertifyService,
    MatDatepickerModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
