import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ComentModel } from 'src/app/forum/models/comentModel';
import { UserModel } from 'src/app/forum/models/UserModel';
import { ComentService } from 'src/app/forum/services/coment.service';
import { UserService } from 'src/app/forum/services/user.service';

@Component({
  selector: 'app-list-coment',
  templateUrl: './list-coment.component.html',
  styleUrls: ['./list-coment.component.css']
})
export class ListComentComponent implements OnInit {
  user:UserModel;
  buscar;
  constructor(public comentService:ComentService,public toastr:ToastrService,public userService:UserService) {
    this.user=this.userService.User;
   
   }

  ngOnInit(): void {
    
    this.comentService.obtenerComentarios(this.user);
  }
  eliminarComentario(id:string){
    if(confirm('esta seguro que desea eliminar el nutriente')){
      this.comentService.eliminarComentario(id).subscribe(data =>{
        this.toastr.warning('registro eliminado','el comentario fue eliminado')
        this.comentService.obtenerComentarios(this.user);

      });
    }
  }
  editar(comentario:ComentModel){
    this.comentService.actualizar(comentario);
  }

}
