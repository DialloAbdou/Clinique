using CliniqueDomain.Models;
using CliniqueDomain.Tools;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;

namespace CliniqueService.domainServices
{
    public class MedecinService : IMedecinService
    {
        private IMedecinRepository _medecinRepository;
        public MedecinService( IMedecinRepository medecinRepository)
        {
            _medecinRepository = medecinRepository;
        }

        /// <summary>
        /// ajout d'un médecin
        /// </summary>
        /// <param name="medecin"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public async Task<Medecin> AddMedecinAsync(Medecin medecin)
        {
            var nbreMedecin = await GetNbMedecin();
            if(nbreMedecin >=(Int32)Limites.A_DeuxMedecins)
            {
                throw new IndexOutOfRangeException($"le service des urgences dispose {nbreMedecin} medecins");
            }
            return await _medecinRepository.AddMedecinAsync(medecin);
        }

        /// <summary>
        /// liste des medecins
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Medecin>> GetAllMedecinAsync()
        {
            return await _medecinRepository.GetAllMedecinAsync();
        }

        /// <summary>
        /// elle renvoie nombre de
        /// medecin
        /// </summary>
        /// <returns></returns>
        private async Task<int> GetNbMedecin()
        {
            var listMedecin = await _medecinRepository.GetAllMedecinAsync();
              return listMedecin.Count();
        }
    }
}
