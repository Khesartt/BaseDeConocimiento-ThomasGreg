import { HttpClient } from '@angular/common/http';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ComentModel } from '../models/comentModel';
import { UserModel } from '../models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class ComentService {


  myAppUrl = 'https://localhost:44319/';
  comentUrl = 'api/coment/listartodo';
  comentUrlPost = 'api/coment/enviarcomentario';
  comentUrlPut = 'api/coment/editarcomentario/';
  comentUrlDelete = 'api/coment/eliminarcomentario/';
  userUrl = 'api/usuario/listaruno/';
  userUrlAll = 'api/usuario/listartodo';



  listComent: ComentModel[];
  User: UserModel;





  listComentByUser: ComentModel[];

  private actualizarformulario = new BehaviorSubject<ComentModel>({} as any);
  constructor(private http: HttpClient) {



  }

  traerComentarios() {
    this.http.get(this.myAppUrl + this.comentUrl).toPromise()
      .then(data => {
        this.listComent = data as ComentModel[];
        this.listComent.forEach(element => {
          this.http.get(this.myAppUrl + this.userUrl + element.id_usuario).toPromise()
            .then(data => {
              this.User = data as UserModel;
              element.id_usuario = this.User.nombres + " " + this.User.apellidos;

            })
        });

        console.log(this.listComent);

      })
  }
  //metodos para la seccion de usuario
  guardarComentario(comentario: ComentModel): Observable<ComentModel> {
    return this.http.post<ComentModel>(this.myAppUrl + this.comentUrlPost, comentario, { responseType: 'text' as 'json' });
  }

  obtenerComentarios(usuario: UserModel) {

    this.http.get(this.myAppUrl + this.comentUrl).toPromise()
      .then(data => {
        this.listComentByUser = data as ComentModel[];
        let aux = new Array();
        for (let element of this.listComentByUser) {
          if (element.id_usuario == usuario.id_usuario) {
            aux.push(element);
          }
        }
        this.listComentByUser = aux;
      })
  }

  eliminarComentario(id: String): Observable<ComentModel> {
    return this.http.delete<ComentModel>(this.myAppUrl + this.comentUrlDelete + id, { responseType: 'text' as 'json' })
  }
  actualizarComentario(id: string, comentario: ComentModel): Observable<ComentModel> {
    return this.http.put<ComentModel>(this.myAppUrl + this.comentUrlPut + id, comentario, { responseType: 'text' as 'json' });
  }
  actualizar(comentario: ComentModel) {
    this.actualizarformulario.next(comentario);
  }
  obtenerComentario(): Observable<ComentModel> {
    return this.actualizarformulario.asObservable();
  }



}
