import IRecipeIngredient from "../ingredients/IRecipeIngredient";
import IBaseRecipe from "./IBaseRecipe";

export default interface IDetailsRecipe extends IBaseRecipe {
  portions: number;
  preparationTime: number;
  cookingTime: number;
  authorUserName: string;
  isFavourite: boolean;
  categoryId: string;
  ingredients: Array<IRecipeIngredient>;
}
