import { HttpClient, HttpParams } from '@angular/common/http';
import { AbstractType, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Category } from '../models/category';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  private _deleteOperationSuccessfulEvent$: Subject<boolean> = new Subject();
  constructor(private http: HttpClient, private router: Router) {}
  get deleteOperationSuccessfulEvent$(): Observable<boolean> {
    return this._deleteOperationSuccessfulEvent$.asObservable();
  }
  public GetCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`https://localhost:44386/api/Categories`);
  }
  public Delete(id: number) {
    this.http
      .delete(`https://localhost:44386/api/Categories/${id}`)
      .subscribe((response) => {
        this._deleteOperationSuccessfulEvent$.next(true);
      });
  }
  public Add(category: string) {
    this.http
      .post<any>('https://localhost:44386/api/Categories', { name: category })
      .subscribe((data) => {
        this.router.navigate(['categiries']);
      });
  }
  public Edit(id: string | null, name: string) {
    const body = { name: name };

    this.http
      .put<any>(`https://localhost:44386/api/Categories/${id}`, body)
      .subscribe((data) => this.router.navigate(['categiries']));
  }
  public Getbyid(id: string | null) {
    return this.http.get<Category>(
      `https://localhost:44386/api/Categories/` + id
    );
  }
}
