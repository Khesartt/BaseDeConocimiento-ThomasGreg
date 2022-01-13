import { Component, OnInit } from '@angular/core';
import { CodeModel } from '../../models/CodeModel';
import { CodeService } from '../../services/code.service';
import { HighlightService } from '../../services/HighlightService';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-especific-code',
  templateUrl: './especific-code.component.html',
  styleUrls: ['./especific-code.component.css']
})
export class EspecificCodeComponent implements OnInit {
  codigo:CodeModel;
  estado;
  test='select * from';
  constructor(public highlightService: HighlightService,public codeService:CodeService,private ref: ChangeDetectorRef) {
    this.highlightService.highlightAll();
    setInterval(() => {
      this.ref.detectChanges()
      this.highlightService.highlightAll();
      this.highlightService.highlightAll();
    }, 500);


   }

  ngOnInit(): void {
   this.highlightService.highlightAll();
   
  }


}
