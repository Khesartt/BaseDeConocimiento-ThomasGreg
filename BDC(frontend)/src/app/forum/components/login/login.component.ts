import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserModel } from '../../models/UserModel';
import { UserService } from '../../services/user.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  listUsers: UserModel[];
  user: UserModel;
  validarUsuario: boolean;
  constructor(private formBuilder: FormBuilder, private router: Router, private userService: UserService, private toastr: ToastrService, private http: HttpClient) {
    this.form = this.formBuilder.group({

      usuario: ['', [Validators.required]],
      contraseña: ['', [Validators.required]],


    })
  }
  ngOnInit(): void {
  }


  ingresoUsuario() {
    const usuario = this.form.get('usuario')?.value;
    const contraseña = this.form.get('contraseña')?.value;
    this.http.get('https://localhost:44319/api/usuario/listartodo').toPromise().then(data => {
      this.listUsers = data as UserModel[];
      this.validarUsuario = false;
      for (let element of this.listUsers) {
        if (element.usuario == usuario && element.contraseña == contraseña) {
          this.user = element;
          this.validarUsuario = true;
        }
      }
      if (this.validarUsuario == true) {
          this.userService.usuarioLogeado( this.user);

          this.redireccion(11);
      }
      else {
        this.toastr.error('el usuario no existe', 'usuario o contraseña incorrectos')
      }
    });



  }





  redireccion(seccion: number) {
    if (seccion == 1) {
      this.router.navigate(['home']);
    }
    else if (seccion == 8) {
      this.router.navigate(['foroGeneral']);

    }
    else if (seccion == 11) {
      this.userService.validadorEstado = true;
      this.router.navigate(['foroGeneral/userSeccion']);
      this.toastr.success('inicio de sesion correcto');
    }
  }
}
