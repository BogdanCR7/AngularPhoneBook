import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { Category } from 'src/app/models/category';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-categoryis',
  templateUrl: './categoryis.component.html',
  styleUrls: ['./categoryis.component.css'],
})
export class CategoryisComponent implements OnInit {
  obsValue: Category[] = [];
  deleteOperationSuccessfulSubscription: Subscription = new Subscription();
  constructor(private categories: CategoriesService, private router: Router) {
    categories.GetCategories().subscribe((value) => (this.obsValue = value));
  }
  ngOnInit(): void {
    this.deleteOperationSuccessfulSubscription =
      this.categories.deleteOperationSuccessfulEvent$.subscribe(
        (isSuccessful) => {
          if (isSuccessful === true) {
            this.categories
              .GetCategories()
              .subscribe((value) => (this.obsValue = value));
          } else {
          }
        }
      );
  }
  Delete(id: number, contactscount: number): void {
    if (contactscount == 0) {
      this.categories.Delete(id);
      this.categories
        .GetCategories()
        .subscribe((value) => (this.obsValue = value));
    } else {
      alert(
        'To delete a category, there should be no contacts with this category'
      );
    }
  }
  Add(): void {
    this.router.navigate(['addcategiries']);
  }
}
