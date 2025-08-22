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
    public static class MaladeEndPoints
    {
        public static IServiceCollection AddMaladeService(this IServiceCollection services)
        {
            services.AddScoped<IMaladeApplication, MaladeApplication>();
            services.AddScoped<IMaladeService, MaladeService>();
            services.AddScoped<IMaladeRepository, MaladeRepository>();
            return services;
        }

        public static RouteGroupBuilder GetMaladeEndPoint(this RouteGroupBuilder group)
        {
            group.MapPost("", AddMaladeAsync);
            group.MapGet("", GetAllMaladiesAsync);
            group.MapGet("/{nomPathologie}", GetMaladieByNameAsync);
            return group;
        }

        private static async Task<IResult> AddMaladeAsync
             ([FromBody] MaladeInput maladeInput,
              [FromServices] IMaladeApplication maladeApplication)
        {
            var _malade = await maladeApplication.AddMaladeAsync(maladeInput.Pathologie);
            return Results.Ok(CliniqueMapping.ToOutputMalade(_malade));
        }

        private static async Task<IResult> GetAllMaladiesAsync
            ([FromServices] IMaladeApplication maladeApplication)
        {
            var maladies = await maladeApplication.GetAllMaladiesAsync();
            return Results.Ok(maladies.Select(CliniqueMapping.ToOutputMalade));
        }

        /// <summary>
        /// elle renvoie la maladie
        /// </summary>
        /// <param name="nomPathologie"></param>
        /// <param name="maladeApplication"></param>
        /// <returns></returns>             
        private static async Task<IResult> GetMaladieByNameAsync
             ([FromRoute] string nomPathologie,
             [FromServices] IMaladeApplication maladeApplication)
        {
            var maladie = await maladeApplication.GetMaladieByNameAsync(nomPathologie);
            if (maladie == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(CliniqueMapping.ToOutputMalade(maladie));

        }
    }
}
