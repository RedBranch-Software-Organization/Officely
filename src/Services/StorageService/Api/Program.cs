using MediatR;
using RB.SharedKernel.MediatR.Extensions;
using InitializeUserDirectory = Officely.StorageService.Application.Commands.InitializeUserDirectory;
using Officely.StorageService.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/directories", async (InitializeUserDirectory.Command request, IMediator mediator) =>
{
    var result = await mediator.SendCommandAsync(request);
    return Results.Created($"/directories/{result}", result);
})
.WithName("CreateDirectory");

await app.RunAsync();
