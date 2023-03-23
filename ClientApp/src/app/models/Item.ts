import { Category } from "./Category";

export class Item {
  id: number;
  name: string;
  value: number;
  category: Category;

  constructor() {
    this.id = 0;
    this.name = "";
    this.value = 0;
    this.category = new Category();
  }
}
