import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";

import { PagesModule } from './pages/pages.module';

import { ServicesModule } from './services/services.module';

import { APP_ROUTES } from './app.routes';

import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';


@NgModule({
  declarations: [
    AppComponent,
    AuthComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    PagesModule,
    APP_ROUTES,
    ServicesModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
