import { EventEmitter, Injectable, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { aplicationModel } from '../models/aplicationModel';
import { CodeModel } from '../models/CodeModel';
import { productModel } from '../models/productModel';


@Injectable({
  providedIn: 'root'
})
export class CodeService {
  public aplicativo: aplicationModel;
  public producto: productModel;
  public asegurador: number;


  myAppUrl = 'https://localhost:44319/';
  codeUrl = 'api/code/listarcodigos';

  listCode: CodeModel[];
  listCode2: CodeModel[];
  codeOnClick: CodeModel;


  constructor(private http: HttpClient) {

  }

  traerCodigosxProducto() {
    {
      this.http.get(this.myAppUrl + this.codeUrl).toPromise()
        .then(data => {
          this.listCode=data as CodeModel[];
          let aux =new Array;
          this.listCode.forEach(element => {
            if(element.id_producto==this.producto.id_producto){
              aux.push(element);
            }
            this.listCode=aux;
          });
        })

    }
  }
  traerCodigosxAplicativo() {
    {
      this.http.get(this.myAppUrl + this.codeUrl).toPromise()
        .then(data => {
          this.listCode=data as CodeModel[];
          let aux =new Array;
          this.listCode.forEach(element => {
            if(element.id_aplicativo==this.aplicativo.id_aplicativo){
              aux.push(element);
            }
            this.listCode=aux;

          });
        })

    }
  }
}
