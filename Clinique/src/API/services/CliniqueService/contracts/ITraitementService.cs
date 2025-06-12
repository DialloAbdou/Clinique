using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueService.contracts
{
    public interface ITraitementService
    {
        Task<int> GetTraitementTimeByPatient(int maladeId);
        Task<Maladie> GetTraitementMaladieByPatient(int maladeId);
        Task<int> GetAllTimeTraitementPatients();
        Task<decimal> GetTraitementCostByPatient(int maladeId);
        Task<decimal> GetAllCostTraitementPatients();
    }
}
