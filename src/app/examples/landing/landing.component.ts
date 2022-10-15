import { Component, OnInit } from '@angular/core';
import { Produse } from 'app/Models/produse.model';
import { ProduseService } from 'app/Services/produse.service';

@Component({
    selector: 'app-landing',
    templateUrl: './landing.component.html',
    styleUrls: ['./landing.component.scss']
})

export class LandingComponent implements OnInit {
  focus: any;
  focus1: any;

  newproduse: Array<Produse> = [];
  produse: Array<Produse> = [];

  constructor(public proService: ProduseService) { }

  ngOnInit() {
    this.proService.getAllProds().subscribe(el => {
      el.forEach(prod => {
        this.newproduse.push(prod)
      })
      this.produse = this.newproduse.slice(0,3)
      console.log(this.produse)
    })
  }

}
