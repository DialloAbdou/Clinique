using CliniqueApp.Dto;
using CliniqueDomain.Models;

namespace CliniqueApp.Mapping
{
    public static class CliniqueMapping
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public static PatientOutput ToOutputPatient(Patient patient)
        {
            return new PatientOutput
                (
                  NomPrenom: $"{patient.Prenom} {patient.Nom}",
                  Adresse: patient.Adresse,
                  Age : patient.Age
                );
            

        }

        public static Patient ToPatient(PatientInput input)
        {
            return new Patient
            {
                Nom = input.Nom,
                Prenom = input.Prenom,
                Adresse = input.Adresse,
                Age = input.Age,
                 
                
            };
        }

        public static MedecinOutPut ToOutPutMedecin( Medecin medecin)
        {
            return new MedecinOutPut
           (
             NomPrenom: $"{medecin.Prenom} {medecin.Nom}",
             Adresse: medecin.Adresse,
             Age: medecin.Age,
             Token: medecin.Token

           );
        }

        public static MaladeOutput ToOutputMalade(Maladie maladie)
        {
            return new MaladeOutput
                (
                    Pathologie: maladie.Pathologie
                );
        }

        public static SoinOutPut ToOutPutSoin( Soin soin)
        {
            return new SoinOutPut
                (
                     TypeSoin: soin.TypeSoin,
                     Durees: soin.Durees,
                     prix : soin.prix   
                );
        }
    }
}
