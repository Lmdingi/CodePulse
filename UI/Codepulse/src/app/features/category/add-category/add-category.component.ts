import { Component, OnDestroy } from '@angular/core';
import { type AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css'],
})
export class AddCategoryComponent implements OnDestroy {
  model: AddCategoryRequest;
  private AddCategorySubscription?: Subscription;

  constructor(private categoryService: CategoryService) {
    this.model = {
      name: '',
      urlHandle: '',
    };
  }

  onFormSubmit() {
    this.AddCategorySubscription = this.categoryService
      .addCategory(this.model)
      .subscribe({
        next: (response) => {
          console.log('Success');
        },
      });
  }

  ngOnDestroy(): void {
    this.AddCategorySubscription?.unsubscribe();
  }
}
