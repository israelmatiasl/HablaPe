import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { SessionService,
         SessionGuard } from "./services.index";

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  declarations: [],

  providers: [
    SessionService,
    SessionGuard
  ]
})
export class ServicesModule { }
