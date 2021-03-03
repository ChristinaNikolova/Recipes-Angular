//@Injectable({
//  providedIn: 'root'
//})
//export class IngredientUpdateResolver implements Resolve<IIn> {

//  constructor(
//    private categoriesService: CategoriesService
//  ) { }

//  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ICategoryUpdate> {
//    const id: string = route.params['id'];

//    return this.categoriesService.getCategoryForUpdate(id);
//  }
//}
