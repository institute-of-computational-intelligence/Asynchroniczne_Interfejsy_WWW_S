import { Component, Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from "../../models/Product";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

@Injectable()
export class HomeComponent implements OnInit {

  public products: Product[];
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Product[]>("https://localhost:44396/api/product").subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}
