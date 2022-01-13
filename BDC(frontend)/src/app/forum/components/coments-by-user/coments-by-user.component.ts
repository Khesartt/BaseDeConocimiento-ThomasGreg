import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from '../../models/UserModel';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-coments-by-user',
  templateUrl: './coments-by-user.component.html',
  styleUrls: ['./coments-by-user.component.css']
})
export class ComentsByUserComponent implements OnInit {
  user:UserModel;
  constructor(private router:Router,private userService:UserService) {
    this.user=this.userService.User;
   }

  ngOnInit(): void {
    if(this.userService.validadorEstado==true){

    }
    else{
      this.router.navigate(['foroGeneral/login']);
    }
  }

}
