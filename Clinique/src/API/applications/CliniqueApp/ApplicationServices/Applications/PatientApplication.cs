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
            //var _medecin = await _patientService.GetMedecinByNameAsync(nomMedecin);
             var _maladie = await _patientService.GetMaladieByNameAsync(pathologie);
          
            return await _patientService.AddPatientAsync
                                    (
                                         new Patient
                                         {
                                             Nom = nom,
                                             Prenom = prenom,
                                             Adresse = adresse,
                                             Age = age,
                                             MaladieId = _maladie!.Id,                                 
                                             MedecinId = medecinId
                                         }
                                     );

        }

        public async Task<Maladie?> GetMaladieByName(string NomPathologie, int medecinId)
        {
             return await _patientService.GetMaladieByName(NomPathologie, medecinId);
        }


        public Task<Medecin?> GetMedecinById(int medeciId)
        {
            throw new NotImplementedException();
        }
    }
}
