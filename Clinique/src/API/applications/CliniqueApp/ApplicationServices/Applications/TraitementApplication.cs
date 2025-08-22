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
        public async Task<decimal> GetAllCostTraitementPatients(int medecinId)
        {
            return await _traitementService.GetAllCostTraitementPatients(medecinId);
        }

        /// <summary>
        /// elle renvoie la durée total de traitement
        /// de tous les patients
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetAllTimeTraitementPatients(int medecinId)
        {
            return await _traitementService.GetAllTimeTraitementPatients(medecinId);
        }
        /// <summary>
        /// elle renvoie la cout de traitement
        /// d'un patient
        /// </summary>
        /// <param name="maladeId">
        ///  maladie du patient son Id
        /// </param>
        /// <returns></returns>
        public async Task<decimal> GetTraitementCostByPatient(int maladeId)
        {
           return await _traitementService.GetTraitementCostByPatient(maladeId);
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

        /// <summary>
        /// elle renvoie la durée de traitement
        /// par partient
        /// </summary>
        /// <param name="maladeId">
        /// maladie du patient son Id
        /// </param>
        /// <returns></returns>
        public async Task<int> GetTraitementTimeByPatient(int maladeId)
        {
            return await _traitementService.GetTraitementTimeByPatient(maladeId);
        }
    }
}
