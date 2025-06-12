using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueInfrastructure.Contrats
{
    public interface ITraitementRepository
    {
        Task<int>GetTraitementTimeByPatient( int maladeId);
        Task<Maladie> GetTraitementMaladieByPatient(int maladeId);
        Task<decimal> GetTraitementCostByPatient(int maladeId);

    }
}
