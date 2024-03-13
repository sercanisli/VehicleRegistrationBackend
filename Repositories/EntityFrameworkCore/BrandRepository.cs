using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;

namespace Repositories.EntityFrameworkCore
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBrand(Brand brand) => Create(brand);

        public void DeleteOneBrand(Brand brand) => Delete(brand);

        public async Task<IEnumerable<Brand>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Brand> GetByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(v => v.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneBrand(Brand brand) => Update(brand);
    }
}
