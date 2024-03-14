import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from "./components/login/login.component";
import { AccountComponent } from "./components/account/account.component";
import { TokenService } from "../token.service";
import { AuthInterceptor } from "../auth.interceptor";
import { MoneyFormatPipe } from "./pipes/money-format.pipe";
import { AccountNumberPipe } from "./pipes/account-number.pipe";

@NgModule({
  declarations: [AppComponent, RegistrationComponent, LoginComponent, AccountComponent, MoneyFormatPipe, AccountNumberPipe],
  imports: [BrowserModule, HttpClientModule, FormsModule, AppRoutingModule],
  exports: [MoneyFormatPipe, AccountNumberPipe],
  providers: [TokenService, { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule {}
