import { Component, OnInit } from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import { AddCatComponent } from './add-cat/add-cat.component';
import { UpdateCatComponent } from './update-cat/update-cat.component';

@Component({
  selector: 'app-categoriesadmin',
  templateUrl: './categoriesadmin.component.html',
  styleUrls: ['./categoriesadmin.component.scss']
})
export class CategoriesadminComponent implements OnInit {

  constructor(public dialog: MatDialog) {}

  openDialog() {
    this.dialog.open(AddCatComponent);
  }
  openDialog1() {
    this.dialog.open(UpdateCatComponent);
  }
  ngOnInit(): void {
  }

}
