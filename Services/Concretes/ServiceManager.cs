using AutoMapper;
using Repositories.Contract;
using Services.Contracts;

namespace Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IVehicleTypeService> _vehicleTypeService;
        private readonly Lazy<IVehicleService> _vehicleService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IModelService> _modelService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _vehicleService = new Lazy<IVehicleService>(() => new VehicleManager(repositoryManager, mapper));
            _vehicleTypeService = new Lazy<IVehicleTypeService>(() => new VehicleTypeManager(repositoryManager, mapper));
            _brandService = new Lazy<IBrandService>(() => new BrandManager(repositoryManager, mapper));
            _modelService = new Lazy<IModelService>(() => new  ModelManager(repositoryManager, mapper));
        }


        public IVehicleService VehicleService => _vehicleService.Value;

        public IVehicleTypeService VehicleTypeService => _vehicleTypeService.Value;

        public IBrandService BrandService => _brandService.Value;

        public IModelService ModelService => _modelService.Value;
    }
}
