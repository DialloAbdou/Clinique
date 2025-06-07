using CliniqueApp.Dto;
using FluentValidation;

namespace CliniqueApp.Validations
{
    public class PatientValidation :AbstractValidator<PatientInput>
    {
        public PatientValidation()
        {
            RuleFor(p => p.Nom).NotEmpty();
            RuleFor(p => p.Prenom).NotEmpty();
            RuleFor(p=>p.Age).NotEmpty();   
        }
    }
}
