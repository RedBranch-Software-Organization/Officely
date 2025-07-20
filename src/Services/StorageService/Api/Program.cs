using MediatR;
using RB.SharedKernel.MediatR.Extensions;
using CreateDirectory = Officely.StorageService.Application.Commands.CreateDirectory;
using Officely.StorageService.Application.Extensions;
using Officely.CodeService.Api.Client.Extensions;
using Officely.CodeService.Api.Client;
using Officely.CodeService.Api.Client.Models.Generate;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiClient("http://localhost:5251");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/generateCode", async ([AsParameters] int codeType, ICodeService codeService) =>
{
    var response = await codeService.GenerateAsync(codeType, 3); // Default to generating one code

    return Results.Ok(response);
});

app.MapPost("/directories", async (CreateDirectory.Command request, IMediator mediator) =>
{
    var result = await mediator.SendCommandAsync(request);
    return Results.Created($"/directories/{result.CreatedDirectoryId}", result);
})
.WithName("CreateDirectory");

await app.RunAsync();
