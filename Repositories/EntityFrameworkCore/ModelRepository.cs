using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;

namespace Repositories.EntityFrameworkCore
{
    public class ModelRepository : RepositoryBase<Model>, IModelRepository
    {
        public ModelRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneModel(Model model) => Create(model);

        public void DeleteOneModel(Model model) =>Delete(model);

        public async Task<IEnumerable<Model>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<IEnumerable<Model>> GetAllModelsWithDetailsAsync(bool trackChanges) =>
            await _context.Models.Include(m => m.Brand).ToListAsync();

        public async Task<Model> GetByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(v => v.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneModel(Model model) => Update(model);
    }
}
