using RB.SharedKernel.MediatR.Command;

//ToDo: Wonder if this should'nt be named InitializeUserDirectoryCommand
namespace Officely.StorageService.Application.Commands.InitializeUserDirectory;

public record Command(string? Path, string Name, Guid AuthorId) : ICommand<Result>;
