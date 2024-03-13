using Entities.DataTransferObjects;

namespace Services.Contracts
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleTypeDto>> GetAllVehicleTypesAsync(bool trackChanges);
        Task<VehicleTypeDto> GetOneVehicleTypeAsync(int id, bool trackChanges);
        Task<VehicleTypeDto> CreateOneVehicleTypeAsync(VehicleTypeDto vehicleType);
        Task UpdateOneVehicleTypeAsync(int id, VehicleTypeDto vehicleType, bool trackChanges);
        Task DeleteOneVehicleTypeAsync(int id, bool trackChanges);
    }
}
