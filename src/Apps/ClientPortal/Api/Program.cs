using IntegrationEvents.Client;
using MassTransit;
using Officely.UserService.Api.Client;
using Officely.UserService.Api.Client.Extensions;
using Officely.UserService.Api.Client.Models.SignUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

builder.Services.AddApiClient(builder.Configuration["HttpClients:UserService"] 
    ?? throw new InvalidOperationException("UserService base address is not configured."));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapPost("/signup", async (SignUpRequestDto request, IUserService userService, IPublishEndpoint publishEndpoint) =>
{

    var response = await userService.SignUp(new SignUpRequestDto
    {
        Email = request.Email,
        Password = request.Password,
        Username = request.Username
    });

    if (response is null)
        return Results.BadRequest("Sign up failed.");

    var integrationEvent = new ClientRegisteredIntegrationEvent(
        response.User.Id,
        response.User.Email,
        response.User.VerificationCode
    );

    await publishEndpoint.Publish(integrationEvent);
    return Results.Ok(response);
})
.WithName("SignUp");

await app.RunAsync();
