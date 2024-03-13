using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IModelService
    {
        Task<IEnumerable<ModelDto>> GetAllModelsAsync(bool trackChanges);
        Task<ModelDto> GetOneModelAsync(int id, bool trackChanges);
        Task<ModelDto> CreateOneModelAsync(ModelDto model);
        Task UpdateOneModelAsync(int id, ModelDto model, bool trackChanges);
        Task DeleteOneModelAsync(int id, bool trackChanges);
        Task<IEnumerable<Model>> GetAllModelsWithDetailsAsync(bool trackChanges);

    }
}
