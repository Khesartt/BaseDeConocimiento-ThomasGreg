import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComentsByUserComponent } from './components/coments-by-user/coments-by-user.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ForumComponent } from './forum.component';

const routes: Routes = [

  {
    path: '',
    children: [
        { path: '', component: ForumComponent },
        { path: 'login', component: LoginComponent },
        { path: 'register', component: RegisterComponent },
        { path: 'userSeccion', component: ComentsByUserComponent },
        
       
    ]

},


  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ForumRoutingModule { }
