﻿using CliniqueApp.ApplicationServices.Applications;
using CliniqueApp.ApplicationServices.Contrats;
using CliniqueApp.Dto;
using CliniqueApp.Mapping;
using CliniqueInfrastructure.Contrats;
using CliniqueInfrastructure.Repositories;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using FluentValidation;
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
            return services;
        }
        public static RouteGroupBuilder GetPatientEndPoint( this RouteGroupBuilder group)
        {
            group.MapPost("", AddPatientAsync);
            group.MapGet("", GetAllPatientAsync);
            return group;
        }
        
        private static async Task< IResult> AddPatientAsync
           (
             [FromBody] PatientInput patientInput,
             [FromServices] IValidator<PatientInput> validator,
             [FromServices] IPatientApplication patientApplication,
             [FromServices] IMedecinAuthApplication medecinAuthApplication,
             [FromHeader] HttpContext context
            )
        {

            var patientValidate = validator.Validate(patientInput);
            if (!patientValidate.IsValid)
            {
                return Results.BadRequest(patientValidate.Errors);
            }
            var medecinId = await medecinAuthApplication.GetMedecinIdFromTokenAsync(context);
            var _patient = await patientApplication.AddPatientAsync
                                        (
                                             patientInput.Nom,
                                             patientInput.Prenom,
                                             patientInput.Adresse,
                                             patientInput.Age,
                                             patientInput.pathologie,
                                             medecinId.Value
                                         );
            return Results.Ok(CliniqueMapping.ToOutputPatient(_patient));
        }

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
