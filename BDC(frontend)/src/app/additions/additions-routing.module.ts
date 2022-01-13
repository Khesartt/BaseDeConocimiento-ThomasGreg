import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdditionsComponent } from './additions.component';

const routes: Routes = [


  {
    path: '',
    children: [
        { path: '', component: AdditionsComponent },
       
    ]

},

  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdditionsRoutingModule { }
