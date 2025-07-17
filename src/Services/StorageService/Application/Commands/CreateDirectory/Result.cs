using RB.SharedKernel.MediatR.Command;
namespace RB.Storage.StorageService.Application.Commands.CreateDirectory;

public record Result(Guid CreatedDirectoryId) : ICommandResult;
