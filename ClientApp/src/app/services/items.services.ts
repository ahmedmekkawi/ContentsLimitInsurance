import { Injectable } from "@angular/core";
import { apiUrls } from "../api-configuration";
import { Item } from "../models/Item";
import { ApiHelperService } from "./api-helper.service";

@Injectable()
export class ItemsService {
  private itemsUri: string;

  constructor(private apiHelper: ApiHelperService) {
    this.itemsUri = apiUrls.items;
  }

  getItems() {
    return this.apiHelper.get<Item[]>(this.itemsUri);
  }

  deleteItem(id: number) {
    return this.apiHelper.delete<any>(this.itemsUri + '/' + id);
  }

  addItem(item: Item) {
    return this.apiHelper.put<Item, any>(this.itemsUri, item);
  }

}
