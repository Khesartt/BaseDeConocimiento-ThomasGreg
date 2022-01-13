import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdditionsRoutingModule } from './additions-routing.module';
import { AdditionsComponent } from './additions.component';


@NgModule({
  declarations: [
    AdditionsComponent
  ],
  imports: [
    CommonModule,
    AdditionsRoutingModule,
    
  ]
})
export class AdditionsModule { }
