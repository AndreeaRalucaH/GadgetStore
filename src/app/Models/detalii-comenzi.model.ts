import { Comenzi } from "./comenzi.model";
import { Produse } from "./produse.model";

export class DetaliiComenzi {
    idcomanda: number = 0;
    idprodus: number = 0;
    pret: number = 0;
    cantitate: number = 0;
    adresalivrare: string = "";
    numeutilizator: string = "";
    produs: Array<Produse> = [];
    comanda: Array<Comenzi> = [];
}
