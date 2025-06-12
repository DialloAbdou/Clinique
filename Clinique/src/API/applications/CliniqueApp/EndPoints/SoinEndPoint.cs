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
    public static class SoinEndPoint
    {
        public static IServiceCollection AddSoinService(this IServiceCollection services)
        {
            services.AddScoped<ISoinApplication, SoinApplication>();
            services.AddScoped<ISoinService, SoinService>();
            services.AddScoped<ISoinRepository,SoinRepository>();
            return services;
        }

        public static RouteGroupBuilder GetSoinEndPoint(this RouteGroupBuilder group)
        {
            group.MapPost("",AddSoinAsyn);
            return group;
        }
        private static async Task<IResult>AddSoinAsyn
            (
                [FromBody]SoinInput soinInput,
                [FromServices] ISoinApplication soinApplication
            )
        {
            var _soin = await soinApplication.AddSoinAsync
                            (
                                soinInput.TypeSoin,
                                soinInput.Durees,
                                soinInput.Prix
                            );
            return Results.Ok(CliniqueMapping.ToOutPutSoin(_soin));
        }
    }
}
