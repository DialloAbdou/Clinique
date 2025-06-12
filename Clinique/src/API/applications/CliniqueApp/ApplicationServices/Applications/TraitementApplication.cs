using CliniqueApp.ApplicationServices.Contrats;
using CliniqueDomain.Models;
using CliniqueService.contracts;

namespace CliniqueApp.ApplicationServices.Applications
{
    public class TraitementApplication : ITraitementApplication
    {
        private  ITraitementService _traitementService;
        public TraitementApplication(ITraitementService traitementService)
        {
            _traitementService = traitementService;
        }
        /// <summary>
        /// elle renovie le coût total
        /// le traitement de tous les patients
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetAllCostTraitementPatients()
        {
            return await _traitementService.GetAllCostTraitementPatients();
        }

        /// <summary>
        /// elle renvoie la durée total de traitement
        /// de tous les patients
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetAllTimeTraitementPatients()
        {
            return await _traitementService.GetAllTimeTraitementPatients();
        }

        /// <summary>
        /// elle traitement correspondant d'une
        /// maladie
        /// </summary>
        /// <param name="maladeId"></param>
        /// <returns></returns>
        public async Task<Maladie> GetTraitementMaladieByPatient(int maladeId)
        {
            return await _traitementService.GetTraitementMaladieByPatient(maladeId);
        }


    }
}
