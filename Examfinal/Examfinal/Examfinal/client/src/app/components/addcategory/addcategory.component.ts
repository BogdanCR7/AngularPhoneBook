import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoriesService } from '../../services/categories.service';


@Component({
  selector: 'addcategory',
  templateUrl: './addcategory.component.html',
  styleUrls: ['./addcategory.component.css']
})
export class AddcategoryComponent implements OnInit {
  category: string = "";
  constructor(private categoryserve: CategoriesService, private router: Router) { }

  ngOnInit(): void {
  }
  onSubmit(Name: string) {
    this.categoryserve.Add(Name);

  }

}


