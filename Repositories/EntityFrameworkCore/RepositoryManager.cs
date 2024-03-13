using Repositories.Contract;

namespace Repositories.EntityFrameworkCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IVehicleRepository> _vehicleRepository;
        private readonly Lazy<IVehicleTypeRepository> _vehicleTypeRepository;
        private readonly Lazy<IBrandRepository> _brandRepository;
        private readonly Lazy<IModelRepository> _modelRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _vehicleRepository = new Lazy<IVehicleRepository>(() => new VehicleRepository(_context));
            _vehicleTypeRepository = new Lazy<IVehicleTypeRepository>(() => new VehicleTypeRepository(_context));
            _brandRepository = new Lazy<IBrandRepository>(() => new BrandRepository(_context));
            _modelRepository = new Lazy<IModelRepository>(() => new ModelRepository(_context));
        }

        public IVehicleRepository VehicleRepository => _vehicleRepository.Value;
        public IVehicleTypeRepository VehicleTypeRepository => _vehicleTypeRepository.Value;
        public IBrandRepository BrandRepository => _brandRepository.Value;
        public IModelRepository ModelRepository => _modelRepository.Value;

        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }
}
