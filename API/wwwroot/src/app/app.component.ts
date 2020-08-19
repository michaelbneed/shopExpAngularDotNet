//import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CommonModule } from "@angular/common";
import { IProduct } from "./models/product";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title: 'Tendencies Shopping';
  products: IProduct[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:44392/api/Products').subscribe((response: any) => {
    console.log(response);
    this.products = response;
    }, error => {
      console.log(error);
    });
  }
}
