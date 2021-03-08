export default interface IBaseRecipe {
  id: string;
  title: string;
  content: string;
  picture: string;
  categoryId: string;
  categoryName: string;
  recipeLikesCount: number;
  commentsCount: number;
}

