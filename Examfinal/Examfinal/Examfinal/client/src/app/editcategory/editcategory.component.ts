import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../models/category';

import { CategoriesService } from '../services/categories.service';
@Component({
  selector: 'app-editcategory',
  templateUrl: './editcategory.component.html',
  styleUrls: ['./editcategory.component.css'],
})
export class EditcategoryComponent implements OnInit {
  id: string | null = '';
  category!: Category;

  constructor(
    private _Activatedroute: ActivatedRoute,
    private categories: CategoriesService
  ) {
    this._Activatedroute.paramMap.subscribe((params) => {
      this.id = params.get('id');
    });

    categories.Getbyid(this.id).subscribe((value) => {
      this.category = value;
    });
  }
  Send() {
    this.categories.Edit(this.id, this.category.name);
  }
  ngOnInit(): void {}
}
