using System;

var builder = WebApplication.CreateBuilder(args);

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

app.MapPost("/directories", (CreateDirectoryRequest request) =>
{
    // In a real application, you would save the directory to a database
    // or perform other business logic.
    // For this example, we'll just return a Created response.
    var response = new CreateDirectoryResponse(Guid.NewGuid(), request.Path, request.Name);
    return Results.Created($"/directories/{response.Id}", response);
})
.WithName("CreateDirectory");

app.Run();
