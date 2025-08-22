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
        /// elle renvoie la liste des patients
        /// </summary>
        /// <param name="medecinId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> GetAllPatients(int medecinId)
        {
            return await _context.Patients.Where(p=>p.MaladieId == medecinId).ToListAsync();
        }
    }
}
