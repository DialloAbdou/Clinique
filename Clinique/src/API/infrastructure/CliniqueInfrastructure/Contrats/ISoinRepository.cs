using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueInfrastructure.Contrats
{
    public interface ISoinRepository
    {
        Task<Soin>AddSoinAsync(Soin soin);
        Task<IEnumerable<Soin>> GetAllSoinAsync();
    }
}
