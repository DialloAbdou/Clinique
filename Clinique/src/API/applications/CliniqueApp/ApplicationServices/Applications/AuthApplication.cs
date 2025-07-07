using CliniqueApp.ApplicationServices.Contrats;
using CliniqueService.contracts;

namespace CliniqueApp.ApplicationServices.Applications
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IAuthService _authService;
        public AuthApplication(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<int?> GetMedecinIdFromTokenAsync(string token)
        {
            return  await _authService.GetMedecinIdFromTokenAsync(token);
        }
    }
}
