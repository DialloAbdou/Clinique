using CliniqueApp.EndPoints;
using CliniqueInfrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddDbContext<CliniqueDbContext>
    (op => op.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));

// Injection des Services
builder.Services.AddPatientService();
builder.Services.AddMedecinService();
builder.Services.AddMaladeService();
builder.Services.AddSoinService();
builder.Services.AddTraitementService();

var app = builder.Build();
// Call EndPoints
app.MapGroup("/medecin")
    .GetMedecinEndPoint();

app.MapGroup("/patient")
    .GetPatientEndPoint();

app.MapGroup("/malade")
    .GetMaladeEndPoint();

app.MapGroup("/soin")
    .GetSoinEndPoint();

app.MapGroup("/traitement")
    .GetTraitementEndPoint();

app.Run();