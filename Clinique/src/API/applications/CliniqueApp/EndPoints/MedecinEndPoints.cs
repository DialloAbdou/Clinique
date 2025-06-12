using CliniqueApp.ApplicationServices.Applications;
using CliniqueApp.ApplicationServices.Contrats;
using CliniqueApp.Dto;
using CliniqueApp.Mapping;
using CliniqueInfrastructure.Contrats;
using CliniqueInfrastructure.Repositories;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using Microsoft.AspNetCore.Mvc;

namespace CliniqueApp.EndPoints
{
    public static class MedecinEndPoints
    {
        public static IServiceCollection AddMedecinService(this IServiceCollection services)
        {
            services.AddScoped<IMedecinApplication, MedecinApplication>();
            services.AddScoped<IMedecinService, MedecinService>();
            services.AddScoped<IMedecinRepository, MedecinRepository>();
            return services;
        }

        public static RouteGroupBuilder GetMedecinEndPoint(this RouteGroupBuilder group)
        {
            group.MapPost("", AddMedecinAsync);
            return group;
        }
        private static async Task<IResult> AddMedecinAsync
            (
                [FromBody] MedecinInput medecinInput,
                [FromServices]IMedecinApplication medecinApplication
            )
        {
            var _medecin = await medecinApplication.AddMedecin
                                  (
                                    medecinInput.Nom,
                                    medecinInput.Prenom,
                                    medecinInput.Adresse,
                                    medecinInput.Age
                                  );
            return Results.Ok(CliniqueMapping.ToOutPutMedecin(_medecin));
        }
    }
}
