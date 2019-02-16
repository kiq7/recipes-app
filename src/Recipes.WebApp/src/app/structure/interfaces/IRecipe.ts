import { IIngredient } from './IIngredient';

export interface IRecipe {
  id: string;
  name: string;
  serves: number;
  ingredients: IIngredient[];
  directions: string;
  calories: number;
}
