namespace Officely.StorageService.Domain.Interfaces;

public interface IDirectoryService
{
    Task<bool> Exists(string? path);
    Task<DirectoryInfo> CreateDirectory(string path);
}
