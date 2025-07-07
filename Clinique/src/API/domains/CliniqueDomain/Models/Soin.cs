using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueDomain.Models
{
    public class Soin
    {
        public int Id { get; set; }
        public string TypeSoin { get; set; } = string.Empty;
        public int Durees { get; set; }
        public decimal prix { get; set; }
        public ICollection<Maladie> Maladies { get; set; } = new List<Maladie>();

    }
}
