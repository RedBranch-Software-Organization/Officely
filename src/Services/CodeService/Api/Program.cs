using System.Reflection;
using Application.Extensions;
using MediatR;
using RB.SharedKernel.MediatR.Extensions;
using GenerateVerificationCode = Application.Commands.GenerateVerificationCode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/generate", async ([AsParameters] GenerateVerificationCode.Command command, IMediator mediator) 
    => await mediator.SendCommandAsync(command))
.WithName("Generate Code");

await app.RunAsync();