export interface IRecipeModel {
  id: string;
  name: string;
  serves: number;
  calories: number;
  ingredients: string[];
  directions: string;
}
