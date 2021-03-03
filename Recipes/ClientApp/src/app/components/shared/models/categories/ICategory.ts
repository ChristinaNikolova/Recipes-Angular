import ICreateCategory from "./ICreateCategory";

export default interface ICategory extends ICreateCategory {
  id: string;
  recipesCount: number;
}
