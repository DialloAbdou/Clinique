using CliniqueInfrastructure.Contrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueInfrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private CliniqueDbContext _dbContexte;
        public AuthRepository(CliniqueDbContext dbContexte)
        {
            _dbContexte = dbContexte;
        }
        /// <summary>
        /// on recupère l'id du médecin à partir du token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int?> GetMedecinIdFromTokenAsync(string token)
        {
            var _medecin = await _dbContexte.Medecins.FirstOrDefaultAsync(m => m.Token == token);
            if(_medecin == null)
            {
                return null; // ou vous pouvez lancer une exception si vous préférez
            }
            return _medecin.Id; // retourne l'ID du médecin associé au token

        }
    }
}
