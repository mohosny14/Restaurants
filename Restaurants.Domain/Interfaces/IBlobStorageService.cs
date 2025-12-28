namespace Restaurants.Domain.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadToBlobAsync(Stream fileData, string fileName);
}