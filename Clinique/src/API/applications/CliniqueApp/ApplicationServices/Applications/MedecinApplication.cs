using CliniqueApp.ApplicationServices.Contrats;
using CliniqueDomain.Models;
using CliniqueService.contracts;

namespace CliniqueApp.ApplicationServices.Applications
{
    public class MedecinApplication : IMedecinApplication
    {
        private IMedecinService _medecinService;
        public MedecinApplication(IMedecinService medecinService)
        {
            _medecinService = medecinService;
        }

        /// <summary>
        /// ajout d'un médecin
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="adresse"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public async Task<Medecin> AddMedecin(string nom, string prenom, string adresse, int age, string ?Token)
        {
            return await _medecinService.AddMedecinAsync(new Medecin
            {
                Nom = nom,
                Prenom = prenom,
                Adresse = adresse,
                Age = age, 
                Token = Guid.NewGuid().ToString().Substring(0,16)


            });
        }

        public async Task<IEnumerable<Medecin>> GetAllMedecin()
        {
             return await _medecinService.GetAllMedecinAsync();
        }
            
    }
}
