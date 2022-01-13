import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CodeComponent } from '../CodeComponent/code.component';
import { GalleryTVComponent } from './gallery-tv.component';


const routes: Routes = 
[
  {
      path: '',
      children: [
          { path: '', component: GalleryTVComponent },
          { path: 'code', component: CodeComponent}
         
      ]

  },


];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GalleryTVRoutingModule { }
