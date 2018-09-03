import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';

import { PAGES_ROUTES } from './pages.routes';

import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { MessagesComponent } from './messages/messages.component';
import { FriendsComponent } from './friends/friends.component';
import { WorldComponent } from './world/world.component';


@NgModule({
  declarations: [
    PagesComponent,
    HomeComponent,
    ProfileComponent,
    MessagesComponent,
    FriendsComponent,
    WorldComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PAGES_ROUTES,
    SharedModule,
    NgbModule
  ],
  exports: []
})
export class PagesModule { }
