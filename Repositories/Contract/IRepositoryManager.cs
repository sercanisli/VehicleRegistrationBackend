namespace Repositories.Contract
{
    public interface IRepositoryManager
    {
        IVehicleRepository VehicleRepository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }
        IBrandRepository BrandRepository { get; }
        IModelRepository ModelRepository { get; }

        Task SaveChanges();
    }
}
