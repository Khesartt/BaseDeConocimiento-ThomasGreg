import { Component, OnInit } from '@angular/core';
import { CodeModel } from '../../models/CodeModel';
import { CodeService } from '../../services/code.service';

@Component({
  selector: 'app-list-codes',
  templateUrl: './list-codes.component.html',
  styleUrls: ['./list-codes.component.css']
})
export class ListCodesComponent implements OnInit {
  buscar;
  constructor(public codeService:CodeService) { }

  ngOnInit(): void {
  }
  codigoSeleccionado(code:CodeModel){
    this.codeService.listCode2=[];
    this.codeService.listCode2.push(code);
    console.log(code);
    this.ngOnInit();
  }
}
