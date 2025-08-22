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

        /// <summary>
        /// elle retourne la liste de toutes les maladies
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Maladie>> GetAllMaladiesAsync()
        {
            return  await _maladeService.GetAllMaladiesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomPathologie"></param>
        /// <returns></returns>
        public async Task<Maladie?> GetMaladieByNameAsync(string nomPathologie)
        {
           return await _maladeService.GetMaladieByNameAsync(nomPathologie);
        }
    }
}
