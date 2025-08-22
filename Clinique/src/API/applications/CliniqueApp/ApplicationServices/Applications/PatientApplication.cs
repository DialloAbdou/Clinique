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

        /// <summary>
        ///  elle permet d'ajouter tout les patients
        ///  qui se trouve dans la base de donnée
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="adresse"></param>
        /// <param name="age"></param>
        /// <param name="maladieId"></param>
        /// <param name="medecinId"></param>
        /// <returns></returns>
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

        public async Task<IEnumerable<Patient>> GetAllPatients(int medecinId)
        {
            return await _patientService.GetAllPatients(medecinId);
        }   
    }
}
