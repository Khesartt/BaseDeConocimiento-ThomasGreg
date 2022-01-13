import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';



import { aplicationClientModel } from '../models/aplicationClientModel';
import { aplicationModel } from '../models/aplicationModel';
import { businessClientModel } from '../models/businessClientModel';
import { clientModel } from '../models/clientModel';
import { productClientModel } from '../models/productClientModel';
import { productModel } from '../models/productModel';


import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class GalleryTVService {
  myAppUrl = 'https://localhost:44319/';
  businessClientUrl = 'api/businessclient/listarTablaNCT';
  clientUrl = 'api/client/listarclientes';
  aplicationUrl = 'api/aplication/listaraplicativos';
  productUrl = 'api/product/listarproductos';
  clientaplicationUrl = 'api/clientaplication/listartablaact';
  clientproductUrl = 'api/clientproduct/listartablapct';



  listBusinessClient: businessClientModel[];
  listAplicationClient: aplicationClientModel[];
  listProductClient: productClientModel[];
  listClient: clientModel[];
  listProduct: productModel[];
  listAplication: aplicationModel[];


  constructor(private http: HttpClient, private toastr: ToastrService) {

  }


  galeriaTV(cliente: String) {
    let ClienteExiste = false;
    this.http.get(this.myAppUrl + this.businessClientUrl).toPromise()
      .then(data => {
        this.listBusinessClient = data as businessClientModel[];
        let auxBusinessClient = new Array();
        this.listBusinessClient.forEach(element => {
          if (element.id_negocio == 'e81a55f4-3e24-41c2-8522-dc555dfdf696') {
            auxBusinessClient.push(element);
          }
        });
        this.listBusinessClient = auxBusinessClient;//clientes que pertenecen a la linea escogida


        this.http.get(this.myAppUrl + this.clientUrl).toPromise()
          .then(data => {
            this.listClient = data as clientModel[];//obtengo datos de base de datos
            let clients = new Array();//declaro un arreglo solo por los id clientes
            let auxClients = new Array();//declaro un arreglo auxiliar

            this.listBusinessClient.forEach(element => {
              clients.push(element.id_cliente);//agrego en el arreglo solo los clientes que pertenecen a TV (AGREGO SOLO EL GUID)
            });
            //recorro 2 arreglos para buscar solo los clientes necesarios en base a los id del arreglo clients
            this.listClient.forEach(i => {
              clients.forEach(j => {
                if (i.id_cliente == j) {
                  auxClients.push(i);//agrego al aux los objetos cliente de la BD comparando con los clientes de esta linea de negocio
                }
              });
            });
            this.listClient = auxClients;

            this.listClient.forEach(element => {
              if (cliente == element.nombre) {
                ClienteExiste = true;
                //mostramos las tablas
                let id_clienteEscogido = element.id_cliente;


                //datos tabla enlace productos
                this.http.get(this.myAppUrl + this.clientproductUrl).toPromise().then(data => {

                  this.listProductClient = data as productClientModel[];
                  let auxProductClient = new Array();

                  this.listProductClient.forEach(element => {
                    if (element.id_cliente == id_clienteEscogido) {
                      auxProductClient.push(element);
                    }
                  });

                  this.listProductClient = auxProductClient;//clientes que pertenecen a la linea escogida

                  this.http.get(this.myAppUrl + this.productUrl).toPromise()
                    .then(data => {
                      this.listProduct = data as productModel[];

                      let products = new Array();//declaro un arreglo solo por los id clientes
                      let auxProducts = new Array();//declaro un arreglo auxiliar

                      this.listProductClient.forEach(element => {
                        products.push(element.id_producto);//agrego en el arreglo solo los clientes que pertenecen a TV (AGREGO SOLO EL GUID)
                      });
                      //recorro 2 arreglos para buscar solo los clientes necesarios en base a los id del arreglo clients
                      this.listProduct.forEach(i => {
                        products.forEach(j => {
                          if (i.id_producto == j) {
                            auxProducts.push(i);//agrego al aux los objetos cliente de la BD comparando con los clientes de esta linea de negocio
                          }
                        });
                      });
                      this.listProduct = auxProducts;
                      if (this.listProduct.length > 0) {
                        this.toastr.success('el cliente tiene productos asociados', 'productos cargados')
                      }

                      else {
                        this.toastr.warning('el cliente no tiene productos asociados', 'no tengo informacion para dicho cliente')

                      }
                    })
                })

                //inicio de aplicativos
                this.http.get(this.myAppUrl + this.clientaplicationUrl).toPromise()
                  .then(data => {
                    console.log('entre');
                    this.listAplicationClient = data as aplicationClientModel[];
                    let auxAplicationClient = new Array();

                    this.listAplicationClient.forEach(element => {
                      if (element.id_cliente == id_clienteEscogido) {
                        auxAplicationClient.push(element);
                      }
                    });

                    this.listAplicationClient = auxAplicationClient;//clientes que pertenecen a la linea escogida
                    console.log(this.listAplicationClient);

                    this.http.get(this.myAppUrl + this.aplicationUrl).toPromise()
                      .then(data => {
                        this.listAplication = data as aplicationModel[];


                        let aplications = new Array();//declaro un arreglo solo por los id clientes
                        let auxAplications = new Array();//declaro un arreglo auxiliar

                        this.listAplicationClient.forEach(element => {
                          aplications.push(element.id_aplicativo);//agrego en el arreglo solo los clientes que pertenecen a TV (AGREGO SOLO EL GUID)
                        });
                        //recorro 2 arreglos para buscar solo los clientes necesarios en base a los id del arreglo clients
                        this.listAplication.forEach(i => {
                          aplications.forEach(j => {
                            if (i.id_aplicativo == j) {
                              auxAplications.push(i);//agrego al aux los objetos cliente de la BD comparando con los clientes de esta linea de negocio
                            }
                          });
                        });
                        this.listAplication = auxAplications;
                        if (this.listAplication.length > 0) {
                          this.toastr.success('el cliente tiene aplicativos asociados', 'aplicativos cargados')
                        }

                        else {
                          this.toastr.warning('el cliente no tiene aplicativos asociados', 'no tengo informacion para dicho cliente')

                        }
                      })
                  })
              }
            });
            if (ClienteExiste == false) {
              this.listProduct = [];
              this.listAplication = [];

              this.toastr.warning('confirma el nombre del cliente', 'no poseo informacion');
            }
          })
      })

  }
}
