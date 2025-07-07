using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueInfrastructure.Contrats
{
    public interface IAuthRepository
    {
        /// <summary>
        /// elle permet de recuperer 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<int?> GetMedecinIdFromTokenAsync(string token);

    }
}
