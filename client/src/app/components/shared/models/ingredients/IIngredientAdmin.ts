import ICreateIngredient from "./ICreateIngredient";

export default interface IIngredientAdmin extends ICreateIngredient {
  id: string;
  recipeIngredientsCount: number;
}
