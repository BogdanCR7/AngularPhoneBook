import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CategoryisComponent } from './components/categoryis/categoryis.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { AuthService } from './services/auth.service';
import {MatIconModule} from '@angular/material/icon';
import {HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { ContactsService } from './services/contacts.service';
import { CategoriesService } from './services/categories.service';
import { AddcategoryComponent } from './components/addcategory/addcategory.component';
import { EditcategoryComponent } from './editcategory/editcategory.component';
import { MyFilterPipe } from './pipes/myfilter';
import { AddcontactComponent } from './components/addcontact/addcontact.component';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';

@NgModule({
  declarations: [
    AppComponent,
    CategoryisComponent,
    ContactsComponent,
    AddcategoryComponent,
    EditcategoryComponent,
    MyFilterPipe,
    AddcontactComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatIconModule,
    MatButtonModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:() => {
          return localStorage.getItem('access_token');
        },
        allowedDomains: ['localhost:44386'],
        disallowedRoutes:[]
      }
    }),
    BrowserAnimationsModule

  ],
  providers: [AuthService,HttpClientModule,ContactsService,CategoriesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
