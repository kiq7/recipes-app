import { AddRecipePageComponent } from './pages/add-recipe-page/add-recipe-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecipesListComponent } from './components/recipes-list/recipes-list.component';

const appRoutes: Routes = [
  { path: 'cadastrar', component: AddRecipePageComponent },
  { path: 'receitas', component: RecipesListComponent },
  { path: 'receita/:id', component: RecipesListComponent },
  { path: '', component: HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


