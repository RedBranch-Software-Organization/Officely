using Officely.StorageService.Domain.Interfaces;

namespace Officely.StorageService.Infrastructure.Services;

public class DirectoryService : IDirectoryService
{
    public async Task<DirectoryInfo> CreateDirectory(string path)
        => await Task.FromResult(Directory.CreateDirectory(path));

    public async Task<bool> Exists(string? path)
        => await Task.FromResult(Directory.Exists(path));
}
