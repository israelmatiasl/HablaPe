import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { NgbModule, NgbDateParserFormatter, NgbDatepickerI18n } from '@ng-bootstrap/ng-bootstrap';
import { PagesModule } from './pages/pages.module';
import { ServicesModule } from './services/services.module';
import { ComponentsModule } from './components/components.module';

import { APP_ROUTES } from './app.routes';

import { AppComponent } from './app.component';
import { AuthComponent } from './auth/auth.component';

/* Configuración del datepicker, español y formato dd-mm-yyyy */
import { I18n, CustomDatepickerI18n } from './services/formatter/custom-date.service';
import { DateFormatter } from './services/formatter/date-formatter.service';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTES,
    FormsModule,
    ReactiveFormsModule,
    ServicesModule,
    HttpModule,
    PagesModule,
    ComponentsModule,
    NgbModule
  ],
  providers: [I18n, { provide: NgbDateParserFormatter, useClass: DateFormatter }, { provide: NgbDatepickerI18n, useClass: CustomDatepickerI18n }],
  bootstrap: [AppComponent]
})
export class AppModule { }
