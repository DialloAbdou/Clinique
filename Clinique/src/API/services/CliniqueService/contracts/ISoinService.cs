using CliniqueDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueService.contracts
{
    public interface ISoinService
    {
        Task<Soin> AddSoinAsync(Soin soin);
        Task<IEnumerable<Soin>> GetAllSoinAsync();
    }
}
