using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueInfrastructure.Contrats
{
    public interface IMaladeRepository
    {
        Task<Maladie>AddMaladeAssync(Maladie maladie);
        Task<IEnumerable<Maladie>> GetAllMaladiesAsync();
    }
}
