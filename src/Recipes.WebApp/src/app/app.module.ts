import { AddRecipeFormComponent } from './components/add-recipe-form/add-recipe-form.component';
import { IngredientService } from './services/ingredient.service';
import { RecipesPageComponent } from './pages/recipes-page/recipes-page.component';
import { AddRecipePageComponent } from './pages/add-recipe-page/add-recipe-page.component';
import { HeadBarComponent } from './components/shared/headbar/headbar.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatToolbarModule,
  MatIconModule,
  MatListModule,
  MatButtonModule,
  MatTableModule,
  MatPaginatorModule,
  MatSortModule,
  MatCardModule,
  MatDialogModule,
  MatFormFieldModule,
  MatInputModule,
  MatOptionModule
} from '@angular/material';
import { MatSidenavModule } from '@angular/material/sidenav';
import { LayoutModule } from '@angular/cdk/layout';
import { RecipesListComponent } from './components/recipes-list/recipes-list.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { RouterModule } from '@angular/router';
import { RecipeDialogComponent } from './components/recipe-dialog/recipe-dialog.component';
import { RecipeService } from './services';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    RecipesListComponent,
    HeadBarComponent,
    HomePageComponent,
    AddRecipePageComponent,
    RecipesPageComponent,
    RecipeDialogComponent,
    AddRecipeFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    LayoutModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatDialogModule,
    MatListModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    RouterModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule
  ],
  entryComponents: [
    RecipeDialogComponent,
  ],
  providers: [
    RecipeService,
    IngredientService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
