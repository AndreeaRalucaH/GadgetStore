using System;
using System.Collections.Generic;

#nullable disable

namespace ProiectAfaceriElectronice.Models
{
    public partial class Produse
    {
        public Produse()
        {
            Detaliicomenzis = new HashSet<Detaliicomenzi>();
            Feedbackproduses = new HashSet<Feedbackproduse>();
        }

        public int Idprodus { get; set; }
        public string Denumire { get; set; }
        public int Codprodus { get; set; }
        public string Brandcompatibil { get; set; }
        public string Furnizor { get; set; }
        public int? Capacitatestoc { get; set; }
        public int? Pret { get; set; }
        public string Poze { get; set; }

        public virtual ICollection<Detaliicomenzi> Detaliicomenzis { get; set; }
        public virtual ICollection<Feedbackproduse> Feedbackproduses { get; set; }
    }
}
