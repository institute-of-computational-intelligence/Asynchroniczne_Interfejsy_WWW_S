import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from "../../models/Product";
import { Injectable } from '@angular/core';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})

@Injectable()
export class AddProductComponent {
  productModel: Product;
  constructor(private http: HttpClient) {
    this.productModel = new Product();
  }

  onSubmit() {
    this.http.post<Product>("https://localhost:44396/api/product", this.productModel).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
}
