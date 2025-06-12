using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueDomain.Models
{
    public class Patient : Personne
    {
        public int MaladieId { get; set; }
        public virtual Maladie Maladie { get; set; }
        public int MedecinId { get; set; }
        public virtual Medecin Medecin { get; set; }


    }
}
