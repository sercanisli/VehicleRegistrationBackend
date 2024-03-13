namespace Services.Contracts
{
    public interface IServiceManager
    {
        IVehicleService VehicleService { get; }
        IVehicleTypeService VehicleTypeService { get; }
        IBrandService BrandService { get; }
        IModelService ModelService { get; }
    }
}
