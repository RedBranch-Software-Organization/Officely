using RB.SharedKernel.MediatR.Command;

namespace RB.Storage.StorageService.Application.Commands.CreateDirectory;

public record Command(string? Path, string Name) : ICommand<Result>;
