import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { Contact } from '../models/contacts';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  private _deleteOperationSuccessfulEvent$: Subject<boolean> = new Subject();
  constructor(private http:HttpClient,private router: Router) {

  }
  get deleteOperationSuccessfulEvent$(): Observable<boolean> {
    return this._deleteOperationSuccessfulEvent$.asObservable();
}
  public GetContacts(): Observable<Contact[]>{

    return this.http.get<Contact[]>(`https://localhost:44386/api/Contacts`);

  }

  public Add(name: string, description: string, adress: string, email: string, category: string, phoneNumbers:string[]) {

    this.http.post<any>('https://localhost:44386/api/Contacts', {
      name: name, description: description, adress: adress, email: email,
  category:category,phoneNumbers:phoneNumbers }).subscribe(data => {
      this.router.navigate(['contacts']);
    })
  }
  public Delete(id: number) {

    this.http.delete(`https://localhost:44386/api/Contacts/${id}`).subscribe(response =>
     {
      this._deleteOperationSuccessfulEvent$.next(true);
      }
     );
  }
}
