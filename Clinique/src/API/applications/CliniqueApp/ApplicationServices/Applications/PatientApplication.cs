using CliniqueApp.ApplicationServices.Contrats;
using CliniqueDomain.Models;
using CliniqueService.contracts;

namespace CliniqueApp.ApplicationServices.Applications
{
    public class PatientApplication : IPatientApplication
    {
        private IPatientService _patientService;
        public PatientApplication( IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async  Task<Patient> AddPatientAsync
            (
                string nom,
                string prenom,
                string adresse,
                int age, 
                string pathologie,
                int medecinId
            )
        {
            
             var _maladie = await _patientService.GetMaladieByNameAsync(pathologie);
            return await _patientService.AddPatientAsync
                                    (
                                         new Patient
                                         {
                                             Nom = nom,
                                             Prenom = prenom,
                                             Adresse = adresse,
                                             Age = age,
                                             MaladieId = _maladie.Id,
                                             MedecinId = medecinId,
                                            // Medecin = _medecin!

                                         }
                                     );

        }

        public async Task<IEnumerable<Patient>> GetAllPatientAsync()
        {
             return await _patientService.GetAllPatientAsync();
        }

        /// <summary>
        /// elle renvoie le medecin par son id
        /// </summary>
        /// <param name="medeciId"></param>
        /// <returns></returns>
        public async Task<Medecin?> GetMedecinById(int medeciId)
        {
           return await _patientService.GetMedecinById(medeciId);
        }
    }
}
