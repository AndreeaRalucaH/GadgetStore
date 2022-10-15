import { Produse } from "./produse.model";

export class FeedbackProduse {
    Idfeedback: number = 0;
    Idprodus: number = 0;
    Descriere: string = "";
    Client: string = "";
    Pozeprodus: string = "";
    Dataadaugare: Date = new Date();
    Produse: Array<Produse> = [];
}
