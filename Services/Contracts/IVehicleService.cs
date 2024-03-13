using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync(bool trackChanges);
        Task<VehicleDto> GetOneVehicleAsync(int id, bool trackChanges);
        Task<VehicleDto> CreateOneVehicleAsync(VehicleDto vehicle);
        Task UpdateOneVehicleAsync(int id, VehicleDto vehicle, bool trackChanges);
        Task DeleteOneVehicleAsync(int id, bool trackChanges);
        Task<IEnumerable<Vehicle>> GetAllVehiclesWithDetailsAsync(bool trackChanges);
    }
}
