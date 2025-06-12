using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueDomain.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public int Age { get; set; }

    }
}
