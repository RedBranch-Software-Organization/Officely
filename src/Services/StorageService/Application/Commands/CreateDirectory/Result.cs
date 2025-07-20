using RB.SharedKernel.MediatR.Command;
namespace Officely.StorageService.Application.Commands.CreateDirectory;

public record Result(Guid CreatedDirectoryId) : ICommandResult;
