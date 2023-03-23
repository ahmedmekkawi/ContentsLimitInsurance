import { Component } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Category } from '../models/Category';
import { Item } from '../models/Item';
import { CategoriesService } from '../services/categories.services';
import { ItemsService } from '../services/items.services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent {
  items: Item[] = [];
  categories: Category[] = [];
  selectedCategory = null;
  addedItem: Item = new Item();

  constructor(private categoriesService: CategoriesService, private itemsService: ItemsService,
    private confirmationService: ConfirmationService, private messageService: MessageService) {
    this.getItems();
    this.getCategories();
  }

  getCategories() {
    this.categoriesService.getCategories().subscribe((result: Category[]) => {
      this.categories = result;
      this.categories.unshift({ id: 0, name: "-- Select Category --" });
    });
  }

  getItems() {
    this.itemsService.getItems().subscribe((result: Item[]) => {
      this.items = result;
    });
  }

  calculateCategoryItemsTotal(id: number) {
    return this.items.filter(o => o.category.id == id).reduce((value, item) => value + item.value, 0);
  }

  calculateTotalItems() {
    return this.items.reduce((value, item) => value + item.value, 0);
  }

  deleteItem(event: Event, itemId: number) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: 'Are you sure that you want to delete this Item?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.itemsService.deleteItem(itemId).subscribe((result: any) => {
          this.getItems();
          this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'The item has been deleted successfully!' });
        });
      },
      reject: () => {
        //reject action
        this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have changed your mind :)' });
      }
    });
  }

  addItem(event: Event) {
    if (this.addedItem.name != "" && this.addedItem.value > 0 && this.addedItem.category.id > 0) {
      this.confirmationService.confirm({
        target: event.target as EventTarget,
        message: 'Are you sure that you want to add this Item?',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
          this.itemsService.addItem(this.addedItem).subscribe((result: any) => {
            this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'The item has been added successfully!' });
            this.getItems();
            this.clearInputs();
          });
        },
        reject: () => {
          //reject action
          this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have changed your mind :)' });
        }
      });
    } else {
      this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'Invalid Inputs!' });
    }
  }

  clearInputs() {
    this.addedItem = new Item();
  }

}
