import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GalleryPTComponent } from './gallery-pt.component';

const routes: Routes = [

  { path: '', component: GalleryPTComponent},



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GalleryPTRoutingModule { }
