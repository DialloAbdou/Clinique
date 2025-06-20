﻿using CliniqueApp.ApplicationServices.Applications;
using CliniqueApp.ApplicationServices.Contrats;
using CliniqueInfrastructure.Contrats;
using CliniqueInfrastructure.Repositories;
using CliniqueService.contracts;
using CliniqueService.domainServices;
using Microsoft.AspNetCore.Mvc;

namespace CliniqueApp.EndPoints
{
    public static class TraitemenEndpoint
    {
        public static IServiceCollection AddTraitementService(this IServiceCollection services)
        {
            services.AddScoped<ITraitementApplication, TraitementApplication>();
            services.AddScoped<ITraitementService, TraitementService>();
            services.AddScoped<ITraitementRepository, TraitementRepository>();
            return services;
        }

        public static RouteGroupBuilder GetTraitementEndPoint(this RouteGroupBuilder group)
        {
       
            group.MapGet("", GetAllTimeTraitementPatient);
            group.MapGet("/all", GetAllCostTraitementPatient);
            group.MapGet("/{id:int}", GetDureesTraitementByMaladiId);

            return group;
        }

        private static async Task<IResult> GetTraitementByMaladiId
            (
                    [FromRoute] int id,
                    [FromServices] ITraitementApplication traitementApplication
            )
        {
            var maladie = await traitementApplication.GetTraitementMaladieByPatient(id);
            if (maladie == null) return Results.NotFound();
            return Results.Ok(maladie);

        }

        private static async Task<IResult> GetDureesTraitementByMaladiId
      (
              [FromRoute] int id,
              [FromServices] ITraitementApplication traitementApplication
      )
        {
            var Nb = await traitementApplication.GetTraitementTimeByPatient(id);
        
            return Results.Ok(Nb);

        }

        private static async Task<IResult> GetAllTimeTraitementPatient
            (
                  [FromServices] ITraitementApplication traitementApplication
            )
        {
           var durees = await traitementApplication.GetAllTimeTraitementPatients();
            return Results.Ok(durees);
        }


        private static async Task<IResult> GetAllCostTraitementPatient
           (
                 [FromServices] ITraitementApplication traitementApplication
           )
        {
            var sommes = await traitementApplication.GetAllCostTraitementPatients();
            return Results.Ok(sommes);
        }

    }
}
