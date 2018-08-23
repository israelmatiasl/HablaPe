import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChooseImageComponent } from './choose-image/choose-image.component';
import { MyPostComponent } from './my-post/my-post.component';
import { PostComponent } from './post/post.component';

@NgModule({
  declarations: [
      ChooseImageComponent,
      MyPostComponent,
      PostComponent
  ],

  imports: [
    CommonModule
  ],

  exports: [
      ChooseImageComponent,
      MyPostComponent,
      PostComponent
  ]
})
export class ComponentsModule { }