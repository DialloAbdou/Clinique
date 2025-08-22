using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueService.contracts
{
    public interface IMaladeService
    {
        Task<Maladie> AddMaladeAssync(Maladie maladie);
        Task<IEnumerable<Maladie>> GetAllMaladiesAsync();
        Task<Maladie?> GetMaladieByNameAsync(string nomPathologie);
    }
}
