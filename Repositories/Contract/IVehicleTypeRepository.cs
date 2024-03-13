using Entities.Models;

namespace Repositories.Contract
{
    public interface IVehicleTypeRepository : IRepositoryBase<VehicleType>
    {
        Task<IEnumerable<VehicleType>> GetAllAsync(bool trackChanges);
        Task<VehicleType> GetByIdAsync(int id, bool trackChanges);
        void CreateOneVehicleType(VehicleType vehicleType);
        void UpdateOneVehicleType(VehicleType vehicleType);
        void DeleteOneVehicleType(VehicleType vehicleType);
    }
}
