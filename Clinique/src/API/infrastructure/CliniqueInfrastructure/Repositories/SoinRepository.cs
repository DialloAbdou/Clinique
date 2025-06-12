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
    public class SoinRepository : ISoinRepository
    {
        private CliniqueDbContext _context;
        public SoinRepository( CliniqueDbContext context)
        {
            _context = context;
        }

      /// <summary>
      ///  ajout des soins
      /// </summary>
      /// <param name="soin"></param>
      /// <returns></returns>
        public async Task<Soin> AddSoinAsync(Soin soin)
        {
            await _context.Soins.AddAsync(soin);
            await _context.SaveChangesAsync();
            return soin;
        }

        /// <summary>
        /// liste des soins
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Soin>> GetAllSoinAsync()
        {
            return await _context.Soins.ToListAsync();
        }
    }
}
