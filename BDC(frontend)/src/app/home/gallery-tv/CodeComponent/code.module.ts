import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule} from 'ng2-search-filter';
import { FormsModule } from '@angular/forms';
import { HighlightJsModule} from 'ngx-highlight-js';
import { ListCodesComponent } from './list-codes/list-codes.component';
import { EspecificCodeComponent } from './especific-code/especific-code.component';


@NgModule({
  declarations: [
    ListCodesComponent,
    EspecificCodeComponent,
    ListCodesComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    Ng2SearchPipeModule,
    HighlightJsModule,
    
    

  ]
})
export class GalleryTVModule { }
