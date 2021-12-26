import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Contact } from 'src/app/models/contacts';
import { CategoriesService } from 'src/app/services/categories.service';
import { ContactsService } from 'src/app/services/contacts.service';
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ContactsComponent implements OnInit {
  obsValue: Contact[] = [];
  deleteOperationSuccessfulSubscription: Subscription = new Subscription();
  search: string = '';

  obscategory: Category[] = [];
  constructor(
    private contacts: ContactsService,
    private router: Router,
    private categories: CategoriesService
  ) {
    categories.GetCategories().subscribe((value) => (this.obscategory = value));
    contacts.GetContacts().subscribe((value) => (this.obsValue = value));
  }
  ngOnInit(): void {
    this.deleteOperationSuccessfulSubscription =
      this.contacts.deleteOperationSuccessfulEvent$.subscribe(
        (isSuccessful) => {
          if (isSuccessful === true) {
            this.contacts
              .GetContacts()
              .subscribe((value) => (this.obsValue = value));
          } else {
          }
        }
      );
  }
  Delete(id: number): void {
    this.contacts.Delete(id);
    //  this.contacts.GetContacts().subscribe(value => this.obsValue = value);
  }
  Add() {
    this.router.navigate(['addcontact']);
  }
  selectedValue: string = '';
  onSelectedChange(event: any): void {
    this.selectedValue = event;
  }
}
