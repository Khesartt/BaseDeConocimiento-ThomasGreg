import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { ComentModel } from 'src/app/forum/models/comentModel'; 
import { UserModel } from 'src/app/forum/models/UserModel';
import { ComentService } from 'src/app/forum/services/coment.service'; 
import { UserService } from 'src/app/forum/services/user.service';

@Component({
  selector: 'app-add-coment',
  templateUrl: './add-coment.component.html',
  styleUrls: ['./add-coment.component.css']
})
export class AddComentComponent implements OnInit {
  form: FormGroup;
  suscription: Subscription;
  user:UserModel;
  comentario: ComentModel;
  idComent?: string;

  constructor(private formBuilder: FormBuilder, private comentService: ComentService, private toastr: ToastrService,private userService:UserService) {
    this.user=this.userService.User;

    this.form = this.formBuilder.group({
      id: null,
      titulo: ['', [Validators.required]],
      comentarioText: ['', [Validators.required]]
    })
  }
  ngOnDestroy(): void {
    this.suscription.unsubscribe();
  }

  ngOnInit(): void {
    this.suscription = this.comentService.obtenerComentario().subscribe(data => {

      this.comentario = data;
      this.form.patchValue({
        titulo: this.comentario.titulo,
        comentarioText: this.comentario.comentarioText,
       

      });
      this.idComent = this.comentario.id_comentario;
    })
  }
  guardarComentario() {
    if (this.idComent === undefined) {
      this.agregar();
    }
    else {
      this.editar();
    }

  }
  agregar() {
    const comentario: ComentModel = {
      titulo: this.form.get('titulo')?.value,
      comentarioText: this.form.get('comentarioText')?.value,
      id_usuario: this.user.id_usuario,
    

    }
    this.comentService.guardarComentario(comentario).subscribe(data => {
      this.toastr.success('registro agregado', 'el comentario fue agregado');
      this.comentService.obtenerComentarios(this.user);
      this.form.reset();
    })

  }
  editar() {
    const comentario: ComentModel = {
      titulo: this.form.get('titulo')?.value,
      comentarioText: this.form.get('comentarioText')?.value,
      id_usuario: this.user.id_usuario,
    

    }
    this.comentService.actualizarComentario(this.idComent!, comentario).subscribe(data => {
      this.toastr.info('registro actualizado', 'el comentario fue editado');
      this.comentService.obtenerComentarios(this.user);
      this.form.reset();
      this.idComent != null;
    });
  }

}
