using CliniqueDomain.Models;
using CliniqueInfrastructure.Contrats;
using CliniqueService.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqueService.domainServices
{
    public class MaladeService : IMaladeService
    {
        private IMaladeRepository _maladeRepository;
        public MaladeService( IMaladeRepository maladeRepository)
        {
            _maladeRepository = maladeRepository;
        }

        /// <summary>
        /// ajout de Maladie
        /// </summary>
        /// <param name="maladie"></param>
        /// <returns></returns>
        public async Task<Maladie> AddMaladeAssync(Maladie maladie)
        {
            return await _maladeRepository.AddMaladeAssync(maladie);
        }

        /// <summary>
        /// retourne la liste de maladies
        /// enregistre
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Maladie>> GetAllMaladiesAsync()
        {
            return await _maladeRepository.GetAllMaladiesAsync();

        }
    }
}
