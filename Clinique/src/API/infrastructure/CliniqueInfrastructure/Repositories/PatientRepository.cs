using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using Microsoft.EntityFrameworkCore;

namespace CliniqueInfrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private CliniqueDbContext _context;
        public PatientRepository(CliniqueDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// ajout de Patient dans la base De données
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        /// <summary>
        /// elle renvoie la liste des patients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> GetAllPatientAsync()
        {
             return await _context.Patients.ToListAsync();
        }

        /// <summary>
        /// Elle renvoie l'objet Maladie 
        /// dont atteint patient
        /// avec le nom de pathologie en parametre
        /// </summary>
        /// <param name="pathologie"></param>
        /// <returns></returns>
        public async Task<Maladie?> GetMaladieByNameAsync(string pathologie)
        {
           var _maladie = await _context.Maladies.FirstOrDefaultAsync(m => m.Equals(pathologie));
            if (_maladie  is  null)  return null;
            return _maladie;
           
        }

        /// <summary>
        /// elle renvoie le nom du medecin 
        /// du patient
        /// </summary>
        /// <param name="nomMedecin"></param>
        /// <returns></returns>
        public async Task<Medecin?> GetMedecinByNameAsync(string nomMedecin)
        {
            var  medecin = await _context.Medecins.FirstOrDefaultAsync(m=>m.Equals(nomMedecin));
            return medecin;
        }
    }
}
