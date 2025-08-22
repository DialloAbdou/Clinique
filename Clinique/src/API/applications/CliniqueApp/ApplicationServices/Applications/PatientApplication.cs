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

        public async Task<Patient> AddPatientAsync(string nom, string prenom, string adresse, int age, int maladieId , int medecinId)
        {
            return await _patientService.AddPatientAsync(new Patient
            {
                  Nom=nom,
                  Prenom=prenom,
                  Adresse=adresse,
                  Age=age,
                  MaladieId=maladieId,
                 MedecinId=medecinId    
            });
        }

    }
}
