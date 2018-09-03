import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { LeftBarComponent } from './left-bar/left-bar.component';
import { RightBarComponent } from './right-bar/right-bar.component';

@NgModule({
    declarations: [
        HeaderComponent,
        LeftBarComponent,
        RightBarComponent
    ],

    imports: [
        RouterModule,
        CommonModule
    ],

    exports: [
        HeaderComponent,
        LeftBarComponent,
        RightBarComponent
    ]
})
export class SharedModule { }
