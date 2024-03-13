using Entities.Models;

namespace Repositories.Contract
{
    public interface IBrandRepository : IRepositoryBase<Brand>
    {
        Task<IEnumerable<Brand>> GetAllAsync(bool trackChanges);
        Task<Brand> GetByIdAsync(int id, bool trackChanges);
        void CreateOneBrand(Brand brand);
        void UpdateOneBrand(Brand brand);
        void DeleteOneBrand(Brand brand);
    }
}
