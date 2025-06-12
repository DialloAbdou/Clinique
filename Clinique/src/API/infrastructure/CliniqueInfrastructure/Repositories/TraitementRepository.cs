using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using Microsoft.EntityFrameworkCore;

namespace CliniqueInfrastructure.Repositories
{
    public class TraitementRepository : ITraitementRepository
    {
        private CliniqueDbContext _context;
        public TraitementRepository(CliniqueDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Coût de traitement par Patient
        /// </summary>
        /// <param name="maladeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<decimal> GetTraitementCostByPatient(int maladeId)
        {
            var _maladie = await _context.Maladies
                                   .Where(m => m.Id == maladeId)
                                   .Include(s => s.Soins).FirstOrDefaultAsync();

            if (_maladie is null) throw new NotImplementedException();

            var somme = _maladie.Soins.Select(s => s.prix).Sum();
            return somme;
        }

        /// <summary>
        /// elle renvoie 
        /// le soins correspondant
        /// d'un traitement
        /// </summary>
        /// <param name="maladeId"></param>
        /// <returns></returns>
        public async  Task<Maladie> GetTraitementMaladieByPatient(int maladeId)
        {
                       var _maladie =    await _context.Maladies
                                      .Where(m => m.Id == maladeId)
                                      .Include(s => s.Soins).FirstOrDefaultAsync();

            if (_maladie is null) return null;
            return _maladie;
            
        
        }

        /// <summary>
        /// Temps de traitement par Patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async  Task<int> GetTraitementTimeByPatient(int maladeId)
        {
            var _maladie = await _context.Maladies
               .Where(m => m.Id == maladeId)
               .Include(s => s.Soins).FirstOrDefaultAsync();

            if(_maladie is null) throw new NotImplementedException();

            var t = _maladie.Soins
                                .Select(m => m.Durees)
                                .Sum();

            return t;
        }
    }
}
