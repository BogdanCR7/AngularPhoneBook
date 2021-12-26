import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs';
import { Category } from 'src/app/models/category';
import { CategoriesService } from 'src/app/services/categories.service';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'app-addcontact',
  templateUrl: './addcontact.component.html',
  styleUrls: ['./addcontact.component.css']
})
export class AddcontactComponent implements OnInit {

  buyTicketForm2: FormGroup = new FormGroup({
    "userName": new FormControl("", Validators.required),
    "description": new FormControl("", Validators.maxLength(50)),
    "email": new FormControl("", Validators.email),
    "address": new FormControl("", Validators.maxLength(50)),
    "phone": new FormControl("", [Validators.required, Validators.pattern("[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}")]),
    "phone1": new FormControl("", Validators.pattern("[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}")),
    "phone2": new FormControl("", Validators.pattern("[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}")),
    "phone3": new FormControl("", Validators.pattern("[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}")),
  });
  obsValue: Category[] = [];
  constructor(private contact: ContactsService, private categories: CategoriesService) {
    categories.GetCategories().subscribe(value => this.obsValue = value);

  }
  ngOnInit(): void {

  }
  selectedValue: string = "";
  onSelectedChange(event: any) {
    alert(event.target.value);
    this.selectedValue = event.target.value;
  }
  onSubmit() {

    if (this.selectedValue) {

      let first: string = this.buyTicketForm2.get("phone")!.value;
      let second: string = this.buyTicketForm2.get("phone1")!.value;
      let third: string = this.buyTicketForm2.get("phone2")!.value;
      let fourth: string = this.buyTicketForm2.get("phone3")!.value;

      this.contact.Add(this.buyTicketForm2.get("userName")?.value,
        this.buyTicketForm2.get("description")?.value,
        this.buyTicketForm2.get("address")?.value,
        this.buyTicketForm2.get("email")?.value,
        this.selectedValue,
        [first, second, third, fourth]);


    }
  }
}
