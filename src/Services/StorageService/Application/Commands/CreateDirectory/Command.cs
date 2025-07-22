using RB.SharedKernel.MediatR.Command;

namespace Officely.StorageService.Application.Commands.CreateDirectory;

public record Command(string? Path, string Name) : ICommand<Result>;
