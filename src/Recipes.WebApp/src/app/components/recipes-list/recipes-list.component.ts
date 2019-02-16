import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { RecipesListDataSource } from './recipes-list-datasource';
import { IRecipe } from 'src/app/structure/interfaces';
import { RecipeDialogComponent } from '../recipe-dialog/recipe-dialog.component';
import { RecipeService } from 'src/app/services';

@Component({
  selector: 'app-recipes-list',
  templateUrl: './recipes-list.component.html',
  styleUrls: ['./recipes-list.component.css']
})
export class RecipesListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: RecipesListDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['name', 'actions'];

  constructor(public dialog: MatDialog, public recipeService: RecipeService) {}

  ngOnInit() {
    this.dataSource = new RecipesListDataSource(this.paginator, this.sort, this.recipeService);
  }

  openRecipeDialog(recipe: IRecipe) {
    const { id, name, directions, ingredients, serves, calories } = recipe;

    this.dialog.open(RecipeDialogComponent, {
      data: { id, name, directions, ingredients, serves, calories }
    });
  }
}
