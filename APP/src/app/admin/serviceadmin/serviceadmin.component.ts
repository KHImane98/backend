import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { AddServiceComponent } from './add-service/add-service.component';
import { UpdateServiceComponent } from './update-service/update-service.component';

@Component({
  selector: 'app-serviceadmin',
  templateUrl: './serviceadmin.component.html',
  styleUrls: ['./serviceadmin.component.scss']
})
export class ServiceadminComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(AddServiceComponent);
  }
  openDialog1() {
    this.dialog.open(UpdateServiceComponent);
  }
  ngOnInit(): void {
  }

}
