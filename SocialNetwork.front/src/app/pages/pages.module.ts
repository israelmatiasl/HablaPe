import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SharedModule } from '../shared/shared.module';
import { ComponentsModule } from '../components/components.module';

import { PAGES_ROUTES } from './pages.routes';

import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';


@NgModule({
  declarations: [
    PagesComponent,
    HomeComponent,
    ProfileComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PAGES_ROUTES,
    ComponentsModule
  ],
  exports: []
})
export class PagesModule { }
