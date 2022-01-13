import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule} from 'ng2-search-filter';
import { FormsModule } from '@angular/forms';
import { GalleryTVRoutingModule } from './gallery-tv-routing.module';
import { GalleryTVComponent } from './gallery-tv.component';
import { CodeComponent } from '../CodeComponent/code.component';
import { ListCodesComponent } from '../CodeComponent/list-codes/list-codes.component';
import { EspecificCodeComponent } from '../CodeComponent/especific-code/especific-code.component';


@NgModule({
  declarations: [
    GalleryTVComponent,
    CodeComponent,
    ListCodesComponent,
    EspecificCodeComponent

   

  ],
  imports: [
    CommonModule,
    GalleryTVRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    Ng2SearchPipeModule,
    

  ]
})
export class GalleryTVModule { }
