using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using Microsoft.EntityFrameworkCore;

namespace CliniqueInfrastructure.Repositories
{
    public class MedecinRepository : IMedecinRepository
    {
        private CliniqueDbContext _context;
        public MedecinRepository(CliniqueDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// ajout des medecins
        /// </summary>
        /// <param name="medecin"></param>
        /// <returns></returns>
        public async Task<Medecin> AddMedecinAsync(Medecin medecin)
        {
            await _context.Medecins.AddAsync(medecin);
            await _context.SaveChangesAsync();
            return medecin;
        }

        /// <summary>
        /// la liste des medecins
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Medecin>> GetAllMedecinAsync()
        {
            return await _context.Medecins.ToListAsync();
        }
    }
}
