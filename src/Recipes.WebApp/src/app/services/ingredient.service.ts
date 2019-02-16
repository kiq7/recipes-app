import { IIngredient } from './../structure/interfaces';
import { throwError as observableThrowError,  Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable()
export class IngredientService {
  constructor(private http: HttpClient) {}

  get(): Observable<IIngredient[]> {
    return this.http.get(`${environment.serviceUrl}/ingredientes`).pipe(
      map((res: IIngredient[]) => res),
      catchError(error => {
        return observableThrowError(error);
      }));
  }
}
