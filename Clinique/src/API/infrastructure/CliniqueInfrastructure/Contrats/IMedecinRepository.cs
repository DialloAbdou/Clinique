using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueInfrastructure.Contrats
{
    public interface IMedecinRepository
    {
        Task<Medecin> AddMedecinAsync(Medecin medecin);
        Task<IEnumerable<Medecin>> GetAllMedecinAsync();
    }
}
