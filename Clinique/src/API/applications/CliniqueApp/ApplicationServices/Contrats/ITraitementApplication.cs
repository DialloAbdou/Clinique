﻿using CliniqueDomain.Models;

namespace CliniqueApp.ApplicationServices.Contrats
{
    public interface ITraitementApplication
    {
        Task<int> GetTraitementTimeByPatient(int maladeId);
        Task<Maladie> GetTraitementMaladieByPatient(int maladeId);
        Task<int> GetAllTimeTraitementPatients();
        Task<decimal> GetTraitementCostByPatient(int maladeId);
        Task<decimal> GetAllCostTraitementPatients();
    }
}
