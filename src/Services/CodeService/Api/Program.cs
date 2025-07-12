using Application.Commands.GenerateVerificationCode;
using MediatR;
using RB.SharedKernel.MediatR.Extensions;
using RB.Storage.CodeService.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssemblyContaining<GenerateVerificationCodeCommandHandler>();
});
builder.Services.AddCodeService();
// builder.Services.AddSharedKernelMediatR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/generate", async ([AsParameters] GenerateVerificationCodeCommand command, IMediator mediator) 
    => await mediator.SendCommandAsync(command))
.WithName("Generate Code");

await app.RunAsync();