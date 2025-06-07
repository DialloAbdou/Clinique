using CliniqueApp.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
var app = builder.Build();
app.MapGet("/patient", () => "Hello patient");

app.MapPost("/patient",
    (
         [FromBody] PatientInput patientInput,
         [FromServices] IValidator<PatientInput> validator
    ) =>
{
    var patientValidate = validator.Validate(patientInput);
    if (!patientValidate.IsValid)
    {
        return Results.BadRequest(patientValidate.Errors);
    }
    return Results.Ok(new PatientOutput());

}); 
app.Run();