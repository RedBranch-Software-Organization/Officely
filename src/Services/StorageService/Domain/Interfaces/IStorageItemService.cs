using System;
using Officely.StorageService.Domain.Entities;

namespace Officely.StorageService.Domain.Interfaces;

public interface IStorageItemService
{
    Task<StorageItem> InitializeCustomerDirectoryAsync(Guid authorId, string basePath);
}
