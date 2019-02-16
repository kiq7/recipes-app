import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { Component, Inject } from '@angular/core';
import { IRecipe } from 'src/app/structure/interfaces';

@Component({
  selector: 'app-recipe-dialog',
  templateUrl: 'recipe-dialog.component.html',
  styleUrls: ['recipe-dialog.component.css']
})
export class RecipeDialogComponent {
  constructor(public dialogRef: MatDialogRef<RecipeDialogComponent>, @Inject(MAT_DIALOG_DATA) public recipe: IRecipe) {}

  onBackClick(): void {
    this.dialogRef.close();
  }

  getIngredientsText(): string {
    return this.recipe.ingredients.map(ingredient => {
      return ingredient.name;
    }).join(', ');
  }
}
