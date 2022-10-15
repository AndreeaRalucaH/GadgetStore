import { Component, OnInit } from '@angular/core';
import { Comenzi } from 'app/Models/comenzi.model';
import { DetaliiComenzi } from 'app/Models/detalii-comenzi.model';
import { Produse } from 'app/Models/produse.model';
import { ComenziService } from 'app/Services/comenzi.service';
import { DetaliiComandaService } from 'app/Services/detalii-comanda.service';
import { ProduseService } from 'app/Services/produse.service';

@Component({
  selector: 'app-produse-page',
  templateUrl: './produse-page.component.html',
  styleUrls: ['./produse-page.component.css']
})
export class ProdusePageComponent implements OnInit {

  produse: Array<Produse> = [];
  comanda: Comenzi = new Comenzi();
  detaliiCom: DetaliiComenzi = new DetaliiComenzi();

  constructor(public proService: ProduseService, public comService: ComenziService, public detService: DetaliiComandaService) { }

  ngOnInit() {
    this.proService.getAllProds().subscribe(el => {
      el.forEach(prod => {
        this.produse.push(prod)
      })
      console.log(this.produse)
    })
  }

  addToCart(prod: Produse){
    console.log(prod)
    this.comanda.datacomanda = new Date();
    this.comanda.datalivrare = null;
    this.comService.postCom(this.comanda).subscribe(el =>{
      console.log(el)
      this.detaliiCom.idcomanda = el.idcomanda;
      this.detaliiCom.idprodus = prod.idprodus;
      this.detaliiCom.pret = prod.pret;
      this.detaliiCom.cantitate = 1;
      this.detService.postComDet(this.detaliiCom).subscribe(res => {
        console.log(res)
      })
    })
  }

}
