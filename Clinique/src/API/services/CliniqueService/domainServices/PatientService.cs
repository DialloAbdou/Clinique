using CliniqueDomain.Models;
using CliniqueDomain.Tools;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using SQLitePCL;

namespace CliniqueService.domainServices
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// ajout Patient dans repositoryPatient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
             var nbPatients = await GetNbrPatients();
            if (nbPatients >= (Int32)Limites.A_DixPatients)
            {
                throw new IndexOutOfRangeException($"le service des urgences {nbPatients} admission de patients");
            }
            var _patient = await _patientRepository.AddPatientAsync(patient);
            return patient;
        }
        /// <summary>
        /// elle renvoie la liste de patients
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<Patient>> GetAllPatientAsync()
        {
            return await _patientRepository.GetAllPatientAsync();
        }

        /// <summary>
        /// elle renvoie la maladie du patient
        /// </summary>
        /// <param name="maladieId"></param>
        /// <returns></returns>
        public async Task<Maladie?> GetMaladieByIdAsync(int maladieId)
        {
           return  await _patientRepository.GetMaladieByIdAsync(maladieId);
        }

        public Task<Medecin?> GetMaladieByIdAsync(string nomMedecin)
        {
            throw new NotImplementedException();
        }

        public async Task<Maladie?> GetMaladieByName(string NomPathologie, int medecinId)
        {
            return  await _patientRepository.GetMaladieByName(NomPathologie, medecinId);
        }

        /// <summary>
        /// elle renvoie la maladie du patient
        /// </summary>
        /// <param name="pathologie"></param>
        /// <returns></returns>
        public async Task<Maladie?> GetMaladieByNameAsync(string pathologie)
        {
             return await _patientRepository.GetMaladieByNameAsync(pathologie);
        }

        /// <summary>
        /// elle renvoie l'objet Medecin
        /// </summary>
        /// <param name="medeciId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Medecin?> GetMedecinById(int medeciId)
        {
            return await _patientRepository.GetMedecinById(medeciId); 
        }



        /// <summary>
        /// le nombre de patient inscrit dans
        /// la base 
        /// </summary>
        /// <returns></returns>
        private async Task< int> GetNbrPatients()
        {
           var _listPatient = await GetAllPatientAsync();
            return _listPatient.Count();
        }
    }
}
