import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ValidatorsComponent } from './validators/validators.component';
import { AlertMessageComponent } from './alert-message/alert-message.component';


@NgModule({
    declarations: [
      ValidatorsComponent,
      AlertMessageComponent
    ],
    
    imports: [
        CommonModule
    ],
    
    exports: [
        ValidatorsComponent,
        AlertMessageComponent
    ]
})
export class ComponentsModule { }