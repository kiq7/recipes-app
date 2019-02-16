import { FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { IRecipeModel } from 'src/app/structure/models/IRecipeModel';
import { RecipeService } from 'src/app/services';
import { AddRecipeValidation } from './add-recipe.form.validation';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-recipe-form',
  templateUrl: 'add-recipe-form.component.html',
  styleUrls: ['add-recipe-form.component.css'],
  providers: [AddRecipeValidation]
})
export class AddRecipeFormComponent implements OnInit {
  form: FormGroup;

  constructor(
    private router: Router,
    public model: IRecipeModel,
    public recipeService: RecipeService,
    public addRecipeValidation: AddRecipeValidation
  ) {}

  ngOnInit() {
    this.form = this.addRecipeValidation.formControl(
      this.model
    );
  }
}
