using Entities.Models;

namespace Repositories.Contract
{
    public interface IModelRepository : IRepositoryBase<Model>
    {
        Task<IEnumerable<Model>> GetAllAsync(bool trackChanges);
        Task<Model> GetByIdAsync(int id, bool trackChanges);
        void CreateOneModel(Model model);
        void UpdateOneModel(Model model);
        void DeleteOneModel(Model model);
        Task<IEnumerable<Model>> GetAllModelsWithDetailsAsync(bool trackChanges);
    }
}
