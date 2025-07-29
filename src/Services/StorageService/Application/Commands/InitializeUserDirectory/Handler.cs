using Microsoft.Extensions.Configuration;
using Officely.StorageService.Domain.Interfaces;
using RB.SharedKernel.MediatR.Command;

namespace Officely.StorageService.Application.Commands.InitializeUserDirectory;

public class Handler(IConfiguration configuration, IStorageItemService storageItemService) : ICommandHandler<Command, Result>
{
    private readonly string _basePath = configuration["StorageRootDirectory"]
        ?? throw new InvalidOperationException("StorageRootDirectory is not configured.");

    public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
    {
        var storageItem = await storageItemService.InitializeCustomerDirectoryAsync(request.AuthorId, _basePath);
        return await Task.FromResult(new Result(storageItem));
    }
}
