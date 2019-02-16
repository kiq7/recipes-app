import { Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { IRecipeModel } from 'src/app/structure/models/IRecipeModel';

@Injectable()
export class AddRecipeValidation {
  public formControl(model: IRecipeModel): FormGroup {
    return new FormGroup({
      name: new FormControl(model.name, [
        Validators.required,
        Validators.maxLength(50)
      ]),
      calories: new FormControl(model.calories, [
        Validators.required,
        Validators.maxLength(10)
      ]),
      serves: new FormControl(model.serves, [
        Validators.required,
        Validators.maxLength(10)
      ]),
      ingredients: new FormControl(model.ingredients, [
        Validators.required,
        Validators.minLength(1)
      ]),
      directions: new FormControl(model.directions, [
        Validators.required,
        Validators.maxLength(500)
      ])
    });
  }
}
