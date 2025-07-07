using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueService.contracts
{
    public interface IAuthService
    {
        public Task<int?> GetMedecinIdFromTokenAsync(string token);
    }
}
