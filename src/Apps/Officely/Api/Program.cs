using Officely.UserService.Api.Client;
using Officely.UserService.Api.Client.Models.SignUp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapPost("/signup", async (string email, string password, string username, IUserService userService) =>
{

    return await userService.SignUp(new SignUpRequestDto
    {
        Email = email,
        Password = password,
        Username = username
    });
})
.WithName("SignUp");

await app.RunAsync();
