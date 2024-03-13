using Entities.Models;

namespace Repositories.Contract
{
    public interface IVehicleRepository : IRepositoryBase<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetAllAsync(bool trackChanges);
        Task<Vehicle> GetByIdAsync(int id, bool trackChanges);
        void CreateOneVehicle(Vehicle vehicle);
        void UpdateOneVehicle(Vehicle vehicle);
        void DeleteOneVehicle(Vehicle vehicle); 
        Task<IEnumerable<Vehicle>> GetAllVehilesWithDetailsAsync(bool trackChanges);
    }
}
