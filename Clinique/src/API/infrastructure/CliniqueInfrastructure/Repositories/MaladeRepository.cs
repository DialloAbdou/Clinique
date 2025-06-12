using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
