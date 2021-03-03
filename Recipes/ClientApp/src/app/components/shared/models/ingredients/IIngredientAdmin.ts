import ICreateIngredient from "./ICreateIngredient";

export default interface IIngredientAdmin extends ICreateIngredient {
  id: string;
  recipesIngredientsCount: number;
}
