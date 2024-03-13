using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;

namespace Repositories.EntityFrameworkCore
{
    public class VehicleTypeRepository : RepositoryBase<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneVehicleType(VehicleType vehicleType) => Create(vehicleType);

        public void DeleteOneVehicleType(VehicleType vehicleType) => Delete(vehicleType);

        public async Task<IEnumerable<VehicleType>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<VehicleType> GetByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(v => v.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneVehicleType(VehicleType vehicleType) => Update(vehicleType);
    }
}
