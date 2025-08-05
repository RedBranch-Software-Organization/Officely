using Officely.StorageService.Domain.Entities;
using Officely.StorageService.Domain.Interfaces;

namespace Officely.StorageService.Domain.Services;

public class StorageItemService(IDirectoryService directoryService, IStorageItemRepository storageItemRepository) : IStorageItemService
{
    public async Task<StorageItem> InitializeClientDirectoryAsync(Guid authorId, string basePath)
    {
        if (!await directoryService.Exists(basePath))
            throw new DirectoryNotFoundException($"The parent directory '{basePath}' does not exist.");

        var newDirectoryPath = Path.Combine(basePath, authorId.ToString().ToUpperInvariant());
        if (await directoryService.Exists(newDirectoryPath))
            throw new IOException($"The directory '{newDirectoryPath}' already exists.");

        await directoryService.CreateDirectory(newDirectoryPath);
        var ClientDirectory = StorageItem.CreateClientDirectory(authorId);
        return await storageItemRepository.AddAsync(ClientDirectory);
    }
}
