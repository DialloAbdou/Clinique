using CliniqueApp.ApplicationServices.Applications;
using CliniqueApp.ApplicationServices.Contrats;
using CliniqueApp.Dto;
using CliniqueApp.Mapping;
using CliniqueInfrastructure.Contrats;
using CliniqueInfrastructure.Repositories;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CliniqueApp.EndPoints
{
    public static class PatientEndPoints
    {
        public static IServiceCollection AddPatientService( this IServiceCollection services)
        {
            services.AddScoped<IMedecinAuthApplication, MedecinAuthApplication>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IPatientApplication, PatientApplication>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAuthApplication, AuthApplication>();
            return services;
        }
        public static RouteGroupBuilder GetPatientEndPoint( this RouteGroupBuilder group)
        {
            group.MapPost("", AddPatientAsync);
            group.MapGet("", GetAllPatientAsync);
            return group;
        }
        
        /// <summary>
        /// Ajout de patient        
        /// </summary>
        /// <param name="patientInput"></param>
        /// <param name="validator"></param>
        /// <param name="patientApplication"></param>
        /// <param name="authApplication"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private static async Task< IResult> AddPatientAsync
           (
             [FromBody] PatientInput patientInput,
             [FromServices] IValidator<PatientInput> validator,
             [FromServices] IPatientApplication patientApplication,
             [FromServices] IMaladeService maladeService,
             [FromServices] IAuthApplication authApplication,
             HttpContext httpContext

            )
        {

            var patientValidate = validator.Validate(patientInput);
            if (!patientValidate.IsValid)
            {
                return Results.BadRequest(patientValidate.Errors);
            }

            var maladie = await maladeService.GetMaladieByNameAsync(patientInput.pathologie);
            if(maladie == null)  return Results.NotFound(patientInput.pathologie);
            string token = httpContext.Request.Headers["UserToken"].ToString();

            var medecinId = await authApplication.GetMedecinIdFromTokenAsync(token);
            if(!medecinId.HasValue)
            {
                return Results.Unauthorized();
            }

                // ajoutons idMedecin dans patientInput
                var _patient = await patientApplication.AddPatientAsync
                                        (
                                             patientInput.Nom,
                                             patientInput.Prenom,
                                             patientInput.Adresse,
                                             patientInput.Age,
                                             maladie.Id,
                                             medecinId.Value

                                         );
            return Results.Ok(CliniqueMapping.ToOutputPatient(_patient));
        }

        /// <summary>
        /// elle renvoie la liste de patients   
        /// </summary>
        /// <param name="patientService"></param>
        /// <returns></returns>
        private static async Task<IResult> GetAllPatientAsync
            (
              [FromServices] IPatientService patientService
            )
        {
            var _patients = await patientService.GetAllPatientAsync();
            if (_patients is null) return Results.NoContent();
            return Results.Ok(_patients.ToList().ConvertAll(CliniqueMapping.ToOutputPatient));
        }



    }



}
