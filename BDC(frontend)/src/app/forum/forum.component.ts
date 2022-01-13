import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ComentService } from './services/coment.service';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent {
  buscar;
  title = 'BDC';
  constructor(public comentService: ComentService, public toastr: ToastrService) {
  }

  ngOnInit(): void {
     this.comentService.traerComentarios();
  
  }





}
