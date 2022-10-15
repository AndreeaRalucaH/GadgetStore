import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DetaliiComandaService } from 'app/Services/detalii-comanda.service';
// import { MatSnackBar } from '@angular/animations/';
@Component({
    selector: 'app-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
    test : Date = new Date();
    focus;
    focus1;
    isSubmit: boolean = false;
    constructor(public detaliiComServ: DetaliiComandaService, public detService: DetaliiComandaService, private router: Router) { }

    ngOnInit() {}

    saveComanda(){
        this.isSubmit = true;
        this.detaliiComServ.getDetaliiCom().subscribe(el => {
            el.forEach(com => {
                com.numeutilizator = "Yes";
                this.detService.update(com.idcomanda,com).subscribe(elm => {
                    console.log(elm)
                });
            })
        })
        setTimeout( () => {this.router.navigate(['/home'])}, 3000 );
    }
}
