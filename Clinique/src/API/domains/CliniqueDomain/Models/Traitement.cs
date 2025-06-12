using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueDomain.Models
{
    public class Traitement
    {
        public int MaladieId { get; set; }
        public virtual Maladie? Maladie { get; set; }
        public int SoinId { get; set; }
        public virtual Soin? Soin { get; set; }
    }
}
