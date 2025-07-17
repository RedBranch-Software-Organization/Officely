using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using RB.SharedKernel.MediatR.Command;

namespace RB.Storage.StorageService.Application.Commands.CreateDirectory;

public class Handler(IConfiguration configuration) : ICommandHandler<Command, Result>
{
    private readonly string _basePath = configuration["StorageRootDirectory"]
        ?? throw new InvalidOperationException("StorageRootDirectory is not configured.");

    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Directory name cannot be null or empty.", nameof(request.Name));

        var parentDirectoryFullName = Path.Combine(_basePath, request.Path ?? string.Empty);
        if (!Directory.Exists(parentDirectoryFullName))
            throw new DirectoryNotFoundException($"The parent directory '{parentDirectoryFullName}' does not exist.");

        var directoryToCreate = Path.Combine(parentDirectoryFullName, request.Name);
        if (Directory.Exists(directoryToCreate))
            throw new IOException($"The directory '{directoryToCreate}' already exists.");

        Directory.CreateDirectory(directoryToCreate);
        var createdDirectoryId = Guid.NewGuid(); // Generate a unique ID for the created directory

        return await Task.FromResult(new Result(createdDirectoryId));
    }
}
