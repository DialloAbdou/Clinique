using CliniqueApp.ApplicationServices.Contrats;
using CliniqueDomain.Models;
using CliniqueService.contracts;

namespace CliniqueApp.ApplicationServices.Applications
{
    public class MaladeApplication : IMaladeApplication
    {
        private IMaladeService _maladeService;
        public MaladeApplication(IMaladeService maladeService)
        {
            _maladeService = maladeService;
        }

        /// <summary>
        /// ajout d'une maladie dans la Db
        /// </summary>
        /// <param name="pathologie"></param>
        /// <returns></returns>
        public async Task<Maladie> AddMaladeAsync(string pathologie)
        {
            return await _maladeService.AddMaladeAssync(new Maladie
            {
                Pathologie = pathologie

            });
        }
    }
}
