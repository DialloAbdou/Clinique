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
    public class TraitementService : ITraitementService
    {
        private ITraitementRepository _traitementRepository;
        private IPatientRepository _petientRepository;
        public TraitementService
            (
                        ITraitementRepository traitementRepository,
                        IPatientRepository patientRepository
            )
        {
            _traitementRepository  = traitementRepository;
            _petientRepository = patientRepository;
        }
        /// <summary>
        /// elle renvoie le coût total 
        /// du traitement de tous les patients
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetAllCostTraitementPatients()
        {

            var _patients = await _petientRepository.GetAllPatientAsync();
            decimal somme = 0;
            foreach (var p in _patients)
            {
                somme += await GetTraitementCostByPatient(p.MaladieId);
            }
            return somme;

        }

        /// <summary>
        /// elle renvoie les durées total 
        /// du traitements de tous les patients
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetAllTimeTraitementPatients()
        {
            var _patients = await _petientRepository.GetAllPatientAsync();
            int nbrDurees = 0;
            foreach (var p in _patients)
            {
                nbrDurees += await GetTraitementTimeByPatient(p.MaladieId);
            }
            return nbrDurees;   
        }

        /// <summary>
        /// cout total du traitement d'un patient
        /// </summary>
        /// <param name="maladeId"></param>
        /// <returns></returns>
        public async Task<decimal> GetTraitementCostByPatient(int maladeId)
        {
             return await _traitementRepository.GetTraitementCostByPatient(maladeId);
        }

        /// <summary>
        /// elle renvoie une maladie avec son 
        /// traitement
        /// </summary>
        /// <param name="maladeId"></param>
        /// <returns></returns>
        public async Task<Maladie> GetTraitementMaladieByPatient(int maladeId)
        {
            return await _traitementRepository.GetTraitementMaladieByPatient(maladeId);
        }

        /// <summary>
        /// durées total du traitement d'un patient
        /// </summary>
        /// <param name="maladeId"></param>
        /// <returns></returns>
        public async Task<int> GetTraitementTimeByPatient(int maladeId)
        {
            return await _traitementRepository.GetTraitementTimeByPatient(maladeId);
        }
    }
}
