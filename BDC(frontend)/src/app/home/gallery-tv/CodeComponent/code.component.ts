import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CodeService } from '../services/code.service';

@Component({
  selector: 'app-code',
  templateUrl: './code.component.html',
  styleUrls: ['./code.component.css']
})
export class CodeComponent implements OnInit {
  check;
  constructor(public codeService: CodeService, public toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.configuraciones();
  }
 
  configuraciones() {
  if(this.codeService.asegurador==0){
    this.toastr.info('se cargaron los datos del producto '+this.codeService.producto.nombre);
    this.codeService.traerCodigosxProducto();
    this.check=true;

  }
  else if(this.codeService.asegurador==1){
    this.toastr.info('se cargaron los datos del aplicativo '+this.codeService.aplicativo.nombre);
    this.codeService.traerCodigosxAplicativo();
    this.check=true;
  }
  else{
    this.toastr.error('regresa a la seccion anterior y selecciona algo.','no pude cargar los JQuerys del producto/aplicativo')
  }
  }
}
