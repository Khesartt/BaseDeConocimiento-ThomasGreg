import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GalleryGDRoutingModule } from './gallery-gd-routing.module';
import { GalleryGDComponent } from './gallery-gd.component';


@NgModule({
  declarations: [
    GalleryGDComponent
  ],
  imports: [
    CommonModule,
    GalleryGDRoutingModule
  ]
})
export class GalleryGDModule { }
