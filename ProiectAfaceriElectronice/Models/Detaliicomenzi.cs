using System;
using System.Collections.Generic;

#nullable disable

namespace ProiectAfaceriElectronice.Models
{
    public partial class Detaliicomenzi
    {
        public int Idcomanda { get; set; }
        public int Idprodus { get; set; }
        public int Pret { get; set; }
        public int Cantitate { get; set; }
        public string Adresalivrare { get; set; }
        public string Numeutilizator { get; set; }

        public virtual Comenzi IdcomandaNavigation { get; set; }
        public virtual Produse IdprodusNavigation { get; set; }
        //public virtual ICollection<Produse> Detaliicomenzis { get; set; }
    }
}
