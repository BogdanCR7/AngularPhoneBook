import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddcategoryComponent } from './components/addcategory/addcategory.component';
import { AddcontactComponent } from './components/addcontact/addcontact.component';

import { CategoryisComponent } from './components/categoryis/categoryis.component';
import { ContactsComponent } from './components/contacts/contacts.component';

import { EditcategoryComponent } from './editcategory/editcategory.component';

const routes: Routes = [
  { path: 'contacts', component: ContactsComponent },
  { path: 'categiries', component:CategoryisComponent},
  { path: 'addcategiries', component: AddcategoryComponent },
  { path: 'editcategiries/:id', component: EditcategoryComponent },
  { path: 'addcontact', component: AddcontactComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
