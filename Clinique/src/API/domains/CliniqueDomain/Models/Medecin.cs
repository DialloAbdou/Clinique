using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueDomain.Models
{
    public class Medecin: Personne
    {
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public string Token { get; set; } = string.Empty;
    }
}
