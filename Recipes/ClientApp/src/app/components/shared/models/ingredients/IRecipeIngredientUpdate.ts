import IRecipeIngredient from "./IRecipeIngredient";

export default interface IRecipeIngredientUpdate extends IRecipeIngredient {
  recipeId: string;
  ingredientId: string;
}
