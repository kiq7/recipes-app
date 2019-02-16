import { IRecipe } from '../structure/interfaces';
import { throwError as observableThrowError,  Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { IRecipeModel } from '../structure/models/IRecipeModel';
import { environment } from '../../environments/environment';

@Injectable()
export class RecipeService {
  constructor(private http: HttpClient) {}

  post(recipe: IRecipeModel): Observable<IRecipeModel> {
    return this.http.post(`${environment.serviceUrl}/receita`, recipe).pipe(
      map((res: IRecipeModel) => res),
      catchError(error => {
        return observableThrowError(error);
      }));
  }

  get(): Observable<IRecipe[]> {
    return this.http.get(`${environment.serviceUrl}/receitas`).pipe(
      map((res: IRecipe[]) => res),
      catchError(error => {
        return observableThrowError(error);
      }));
  }

  getById(id: string): Observable<IRecipe> {
    return this.http.get(`${environment.serviceUrl}/receitas/${id}`).pipe(
      map((res: IRecipe) => res),
      catchError(error => {
        return observableThrowError(error);
      }));
  }
}
