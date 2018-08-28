import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ValidatorsComponent } from './validators/validators.component';


@NgModule({
    declarations: [
      ValidatorsComponent
    ],
    
    imports: [
        CommonModule
    ],
    
    exports: [
        ValidatorsComponent
    ]
})
export class ComponentsModule { }