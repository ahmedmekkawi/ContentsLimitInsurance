import { Injectable } from "@angular/core";
import { apiUrls } from "../api-configuration";
import { Category } from "../models/Category";
import { ApiHelperService } from "./api-helper.service";

@Injectable()
export class CategoriesService {
  private _categoriesUri: string;

  constructor(private apiHelper: ApiHelperService) {
    this._categoriesUri = apiUrls.categories;
  }

  getCategories() {
    return this.apiHelper.get<Category[]>(this._categoriesUri);
  }

}
