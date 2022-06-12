import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { AddPersonneComponent } from './add-personne/add-personne.component';
import { UpdatePersonneComponent } from './update-personne/update-personne.component';

@Component({
  selector: 'app-personneadmin',
  templateUrl: './personneadmin.component.html',
  styleUrls: ['./personneadmin.component.scss']
})
export class PersonneadminComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(AddPersonneComponent);
  }
  openDialog1() {
    this.dialog.open(UpdatePersonneComponent);
  }
  ngOnInit(): void {
  }

}
