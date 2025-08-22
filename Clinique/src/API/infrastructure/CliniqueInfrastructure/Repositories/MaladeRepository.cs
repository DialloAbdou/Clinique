using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using Microsoft.EntityFrameworkCore;

namespace CliniqueInfrastructure.Repositories
{
    public class MaladeRepository : IMaladeRepository
    {
        private CliniqueDbContext _context;
        public MaladeRepository(CliniqueDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// ajout des medecins
        /// </summary>
        /// <param name="maladie"></param>
        /// <returns></returns>
        public async Task<Maladie> AddMaladeAssync(Maladie maladie)
        {
            await _context.Maladies.AddAsync(maladie);
            await _context.SaveChangesAsync();
            return maladie;

        }
        /// <summary>
        /// liste des maladies
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Maladie>> GetAllMaladiesAsync()
        {
            return await _context.Maladies.ToListAsync();
        }

        public async Task<Maladie?> GetMaladieByNameAsync(string nomPathologie)
        {
            return await _context.Maladies
                .FirstOrDefaultAsync(m=>m.Pathologie == nomPathologie);
        }
    }
}
  