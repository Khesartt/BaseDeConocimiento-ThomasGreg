import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GalleryPTRoutingModule } from './gallery-pt-routing.module';
import { GalleryPTComponent } from './gallery-pt.component';


@NgModule({
  declarations: [
    GalleryPTComponent
  ],
  imports: [
    CommonModule,
    GalleryPTRoutingModule
  ]
})
export class GalleryPTModule { }
