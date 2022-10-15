using System;
using System.Collections.Generic;

#nullable disable

namespace ProiectAfaceriElectronice.Models
{
    public partial class Feedbackproduse
    {
        public int Idfeedback { get; set; }
        public int Idprodus { get; set; }
        public string Descriere { get; set; }
        public string Client { get; set; }
        public string Pozeprodus { get; set; }
        public DateTime Dataadaugare { get; set; }

        public virtual Produse IdprodusNavigation { get; set; }
    }
}
