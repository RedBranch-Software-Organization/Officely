using Officely.StorageService.Domain.Entities;

namespace Officely.StorageService.Domain.Interfaces;

public interface IStorageItemRepository
{
    Task<StorageItem> AddAsync(StorageItem item);
}
