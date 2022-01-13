import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms'
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { timer } from 'rxjs';
import { UserModel } from '../../models/UserModel';
import { ComentService } from '../../services/coment.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  newUser: UserModel;
  validarNombre: boolean;
  listUsers: UserModel[];
  user:UserModel;
  constructor(private formBuilder: FormBuilder, private router: Router, private toastr: ToastrService, public comentService: ComentService,
    public userService: UserService, private http: HttpClient) {
    this.form = this.formBuilder.group({

      nombres: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      usuario: ['', [Validators.required]],
      contraseña: ['', [Validators.required, Validators.minLength(8)]],
      Rcontraseña: ['', [Validators.required, Validators.minLength(8)]],
      correo: ['', [Validators.required, Validators.email]],
      rol: ['', [Validators.required]],

    })
  }


  ngOnInit(): void {
  }

  registroUsuario() {
    const contraseAux1 = this.form.get('contraseña')?.value;
    const contraseñaAux2 = this.form.get('Rcontraseña')?.value;
    if (contraseAux1 == contraseñaAux2) {
      console.log('contraseñas coinciden');
      const usuarioNuevo: UserModel = {
        nombres: this.form.get('nombres')?.value,
        apellidos: this.form.get('apellidos')?.value,
        usuario: this.form.get('usuario')?.value,
        contraseña: this.form.get('contraseña')?.value,
        correo: this.form.get('correo')?.value,
        rol: this.form.get('rol')?.value,
        activo: true
      }

      this.http.get('https://localhost:44319/api/usuario/listartodo').toPromise().then(data => {
        this.listUsers = data as UserModel[];
        this.validarNombre = false;
        for (let element of this.listUsers){
          if (element.usuario == usuarioNuevo.usuario) {
            console.log('dentro del if', this.validarNombre);
            this.validarNombre = true;
          }
        }
        if (this.validarNombre == true) {
          console.log(usuarioNuevo.usuario);
          this.toastr.error('nombre de usuario ya existe')
        }
        else {
          this.userService.agregarUsuario(usuarioNuevo).subscribe(data => {
            this.form.reset();
            this.redireccion(9);
          })

        }

      });
    }
    else {
      this.toastr.error('las contraseñas no coinciden');
    }


  }
  redireccion(seccion: number) {
    if (seccion == 1) {
      this.router.navigate(['home']);
    }
    else if (seccion == 8) {
      this.router.navigate(['foroGeneral']);

    }
    else if (seccion == 9) {
      this.userService.validadorEstado = true;

      this.router.navigate(['foroGeneral/login']);
      this.toastr.success('usuario creado correctamente');

    }

  }



}
