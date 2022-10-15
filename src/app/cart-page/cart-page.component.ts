import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cos } from 'app/Models/cos.model';
import { DetaliiComenzi } from 'app/Models/detalii-comenzi.model';
import { DetaliiComandaService } from 'app/Services/detalii-comanda.service';
import { ProduseService } from 'app/Services/produse.service';

@Component({
  selector: 'app-cart-page',
  templateUrl: './cart-page.component.html',
  styleUrls: ['./cart-page.component.css']
})
export class CartPageComponent implements OnInit {

  comenziCos: Array<Cos> = [];
  total: number = 0;
  constructor(public detaliiComServ: DetaliiComandaService, public prodService: ProduseService, private router: Router) { }

  ngOnInit(): void {
    this.detaliiComServ.getDetaliiCom().subscribe(el => {
      el.forEach(com => {
        if(com.numeutilizator != "Yes"){
          let comenzi = new Cos();
          comenzi.cantitate = com.cantitate;
          comenzi.pret = com.pret;
          this.total += com.pret;
          this.prodService.getProd(com.idprodus).subscribe(prod => {
            comenzi.produs = prod;
          })
          this.comenziCos.push(comenzi);
        }
        

      })
      console.log(this.comenziCos)
    })
  }

  plaseazaComanda(){
    this.router.navigate(['/comanda']);
  }

}
