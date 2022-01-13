import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ComentModel } from '../models/comentModel';
import { UserModel } from '../models/UserModel';

@Injectable({
    providedIn: 'root'
})
export class UserService {


    myAppUrl = 'https://localhost:44319/';
    comentUrl = 'api/coment/listartodo';
    userUrl = 'api/usuario/listartodo';
    userUrlPost = 'api/usuario/enviarusuario';
    listComent: ComentModel[];
    listUsers: UserModel[];
    User: UserModel;
    id:string;
    public validadorEstado: boolean = false;
    public validarUsuario:boolean;

    
    constructor(private http: HttpClient) {



    }
    usuarioLogeado(usuario:UserModel) {
      this.User=usuario;
      console.log(this.User);
    }
    
    agregarUsuario(user: UserModel): Observable<UserModel> {
        return this.http.post<UserModel>(this.myAppUrl + this.userUrlPost, user, { responseType: 'text' as 'json' });

    }


}
