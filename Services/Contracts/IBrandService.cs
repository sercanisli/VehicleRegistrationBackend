using Entities.DataTransferObjects;

namespace Services.Contracts
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool trackChanges);
        Task<BrandDto> GetOneBrandAsync(int id, bool trackChanges);
        Task<BrandDto> CreateOneBrandAsync(BrandDto brand);
        Task UpdateOneBrandAsync(int id, BrandDto brand, bool trackChanges);
        Task DeleteOneBrandAsync(int id, bool trackChanges);
    }
}
