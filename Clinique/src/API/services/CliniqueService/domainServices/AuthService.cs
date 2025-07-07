using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueService.domainServices
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<int?> GetMedecinIdFromTokenAsync(string token)
        {
            return await _authRepository.GetMedecinIdFromTokenAsync(token);

        }
    }
}
