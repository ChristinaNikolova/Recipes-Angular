import IBaseRecipe from "./IBaseRecipe";

export default interface IDetailsRecipe extends IBaseRecipe {
  portions: number;
  preparationTime: number;
  cookingTime: number;
  authorUserName: string;
  isFavourite: boolean;
}
