using System;
using System.Collections.Generic;

#nullable disable

namespace ProiectAfaceriElectronice.Models
{
    public partial class Comenzi
    {
        public Comenzi()
        {
            Detaliicomenzis = new HashSet<Detaliicomenzi>();
        }

        public int Idcomanda { get; set; }
        public DateTime Datacomanda { get; set; }
        public DateTime? Datalivrare { get; set; }

        public virtual ICollection<Detaliicomenzi> Detaliicomenzis { get; set; }
    }
}
