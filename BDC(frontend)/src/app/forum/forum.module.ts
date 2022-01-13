import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ForumRoutingModule } from './forum-routing.module';
import { ForumComponent } from './forum.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { ComentsByUserComponent } from './components/coments-by-user/coments-by-user.component';
import { AddComentComponent } from './components/coments-by-user/add-coment/add-coment.component';
import { ListComentComponent } from './components/coments-by-user/list-coment/list-coment.component';


@NgModule({
  declarations: [
    ForumComponent,
    LoginComponent,
    RegisterComponent,
    ComentsByUserComponent,
    AddComentComponent,
    ListComentComponent
  ],
  imports: [
    CommonModule,
    ForumRoutingModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    FormsModule,
 
  ]
})
export class ForumModule { }
