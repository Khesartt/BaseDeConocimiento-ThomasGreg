import { Component, OnInit } from '@angular/core';
import { GalleryTVService } from '../services/gallery-tv.service';
import { FormGroup,FormBuilder,Validators } from '@angular/forms';
import { aplicationModel } from '../models/aplicationModel';
import { CodeService } from '../services/code.service';


@Component({
  selector: 'app-gallery-tv',
  templateUrl: './gallery-tv.component.html',
  styleUrls: ['./gallery-tv.component.css']
})
export class GalleryTVComponent implements OnInit {
  formClient:FormGroup;
  show=false;
  aplicativoSearch;
  productoSearch;
  aplicativoEscogido;
  
  constructor(public galleryTVService:GalleryTVService,public formBuilderClient:FormBuilder,public codeService: CodeService) { 
    this.formClient=this.formBuilderClient.group({
      id:null,
      nombre:['',[Validators.required]]
    })
  }

  ngOnInit(): void {
    
  }
  clienteSeleccionado(){
    const clienteSeleccionado=this.formClient.get('nombre')?.value;
    this.galleryTVService.galeriaTV(clienteSeleccionado);
    this.formClient.reset();
    
  }
  enviarAplicativo(aplicativoEscogido:aplicationModel,tipo:number){
    if(tipo==1){
      this.codeService.asegurador=1;
      this.codeService.aplicativo=aplicativoEscogido;
    }
    else{
    this.codeService.asegurador=-1;
    }
   }
   enviarProducto(productoEscogido:aplicationModel,tipo:number){
    if(tipo==0){
      this.codeService.asegurador=0;
      this.codeService.producto=productoEscogido;
    }
    else{
      this.codeService.asegurador=-1;
    }
   }
}
