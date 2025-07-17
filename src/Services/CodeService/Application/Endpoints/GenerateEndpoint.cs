using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using RB.SharedKernel.MediatR.Extensions;
using RB.Storage.CodeService.Domain.Enums;
using RB.Storage.CodeService.Domain.Exceptions;
using GenerateCodeCommand = RB.Storage.CodeService.Application.Commands.GenerateCode.Command;
using GenerateCodeResult = RB.Storage.CodeService.Application.Commands.GenerateCode.Result;

namespace RB.Storage.CodeService.Application.Endpoints;
internal static class GenerateEndpoint
{
    private readonly static string pattern = "/generate";

    internal static void MapGenerate(this IEndpointRouteBuilder app)
    {
        app.MapGet(pattern, GenerateAsync)
           .WithName("Generate Code")
           .Produces<GenerateCodeResult>(StatusCodes.Status200OK)
           .Produces<string>(StatusCodes.Status400BadRequest)
           .Produces<string>(StatusCodes.Status500InternalServerError)
           .WithDescription($"Generates code based on the specified code type. Valid code types are between   {CodeType.MinValue} and {CodeType.MaxValue}. If no code type is specified, the default code type will be used.");

    }

    private static async Task<IResult> GenerateAsync([AsParameters] GenerateCodeCommand command, IMediator mediator)
    {
        try
        {
            var result = await mediator.SendCommandAsync(command);
            return Results.Ok(result);
        }
        catch (CodeTypeOutOfRangeException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Results.InternalServerError(ex.Message);
        }
    }
}
