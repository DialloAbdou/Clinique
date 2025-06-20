﻿using CliniqueApp.ApplicationServices.Applications;
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
            return group;
        }

        private static async Task<IResult> AddMaladeAsync
             ([FromBody] MaladeInput maladeInput,
              [FromServices] IMaladeApplication maladeApplication)
        {
            var _malade = await maladeApplication.AddMaladeAsync(maladeInput.Pathologie);
            return Results.Ok(CliniqueMapping.ToOutputMalade(_malade));
        }
    }
}
