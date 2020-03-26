import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from "../model/product";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public products: Product[];
  constructor(http: HttpClient) {
    http.get<Product[]>("https://localhost:44396/api/product").subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}
