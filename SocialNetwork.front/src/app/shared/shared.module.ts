import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';

import { HeaderComponent } from './header/header.component';
import { SidebarLeftComponent } from './sidebar-left/sidebar-left.component';
import { SidebarRightComponent } from './sidebar-right/sidebar-right.component';
import { AsideLeftComponent } from './aside-left/aside-left.component';
import { AsideRightComponent } from './aside-right/aside-right.component';
import { TopComponent } from './top/top.component';

@NgModule({
  declarations: [
    HeaderComponent,
    SidebarLeftComponent,
    SidebarRightComponent,
    AsideLeftComponent,
    AsideRightComponent,
    TopComponent
  ],

  imports: [
    RouterModule,
    CommonModule
  ],

  exports: [
    HeaderComponent,
    SidebarLeftComponent,
    SidebarRightComponent,
    AsideLeftComponent,
    AsideRightComponent,
    TopComponent
  ]
})
export class SharedModule { }
