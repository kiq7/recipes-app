import { IngredientService } from './../../services/ingredient.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { IRecipeModel } from 'src/app/structure/models/IRecipeModel';
import { RecipeService } from 'src/app/services';
import { Router } from '@angular/router';
import { IIngredient } from 'src/app/structure/interfaces';

@Component({
  selector: 'app-add-recipe-form',
  templateUrl: 'add-recipe-form.component.html',
  styleUrls: ['add-recipe-form.component.css'],
})
export class AddRecipeFormComponent implements OnInit {
  recipeForm: FormGroup;
  model: IRecipeModel = {
    name: '',
    calories: 0,
    serves: 0,
    ingredients: [],
    directions: '',
  };
  ingredients: IIngredient[] = [];

  constructor(
    private router: Router,
    public recipeService: RecipeService,
    public ingredientService: IngredientService,
  ) {}

  ngOnInit() {
    this.recipeForm = new FormGroup({
      name: new FormControl(this.model.name, [
        Validators.required,
        Validators.maxLength(50),
        Validators.minLength(1)
      ]),
      calories: new FormControl(this.model.calories, [
        Validators.required,
        Validators.maxLength(10),
        Validators.min(1)
      ]),
      serves: new FormControl(this.model.serves, [
        Validators.required,
        Validators.maxLength(10),
        Validators.min(1)
      ]),
      ingredients: new FormControl(this.model.ingredients, [
        Validators.required,
        Validators.minLength(1)
      ]),
      directions: new FormControl(this.model.directions, [
        Validators.required,
        Validators.minLength(1)
      ])
    });

    this.ingredientService.get().subscribe(res => {
      this.ingredients = res;
    });
  }

  onSubmit() {

    if (this.recipeForm.invalid) {
      alert('Preencha os campos obrigatórios.');
      return null;
    }

    this.recipeService.post(this.recipeForm.value).subscribe(() => {
      alert('Receita cadastrada com sucesso.');
      this.goToHome();
    }, err => {
      console.log(err);
    });
  }

  goToHome() {
    this.router.navigate(['']);
  }
}
