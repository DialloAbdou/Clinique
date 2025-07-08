using CliniqueApp.ApplicationServices.Contrats;
using CliniqueService.contracts;

namespace CliniqueApp.ApplicationServices.Applications
{
    public class MedecinAuthApplication : IMedecinAuthApplication
    {
        private readonly IAuthService _authService;
        public MedecinAuthApplication(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<int?> GetMedecinIdFromTokenAsync(HttpContext context)
        {
            var token = context.Request.Headers["UserToken"].ToString();
            return  await _authService.GetMedecinIdFromTokenAsync(token);
        }
    }
}
