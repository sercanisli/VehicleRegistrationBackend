using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;

namespace Repositories.EntityFrameworkCore
{
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(RepositoryContext context) : base(context) 
        {
        }

        public void CreateOneVehicle(Vehicle vehicle) => Create(vehicle);

        public void DeleteOneVehicle(Vehicle vehicle) => Delete(vehicle);

        public async Task<IEnumerable<Vehicle>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<IEnumerable<Vehicle>> GetAllVehilesWithDetailsAsync(bool trackChanges) =>
            await _context.Vehicles.Include(v => v.Model).Include(v=>v.VehicleType).Include(v=>v.Brand).ToListAsync();

        public async Task<Vehicle> GetByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(v => v.Id == id, trackChanges).SingleOrDefaultAsync();

        public void UpdateOneVehicle(Vehicle vehicle) => Update(vehicle);
    }
}
