import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GalleryGDComponent } from './gallery-gd.component';

const routes: Routes = [

  { path: '', component: GalleryGDComponent},



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GalleryGDRoutingModule { }
