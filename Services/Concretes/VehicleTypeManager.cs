using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contract;
using Services.Contracts;
using Services.ValidationRules.FluentValidation;

namespace Services.Concretes
{
    public class VehicleTypeManager : IVehicleTypeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public VehicleTypeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<VehicleTypeDto> CreateOneVehicleTypeAsync(VehicleTypeDto vehicleType)
        {
            if (vehicleType == null)
            {
                throw new ArgumentNullException(nameof(vehicleType));
            }

            var entity = _mapper.Map<VehicleType>(vehicleType);

            var validator = new VehicleTypeValidator();
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage;
                throw new ArgumentException(errorMessage, nameof(vehicleType));
            }

            var entities = await GetAllVehicleTypesAsync(false);
            foreach (var item in entities)
            {
                if (item.TypeName == entity.TypeName)
                {
                    throw new Exception("TypeName must be uniq");
                }
            }

            _manager.VehicleTypeRepository.CreateOneVehicleType(entity);
            await _manager.SaveChanges();
            return _mapper.Map<VehicleTypeDto>(entity);
        }

        public async Task DeleteOneVehicleTypeAsync(int id, bool trackChanges)
        {
            var entity = await GetOneVehicleTypeAsync(id, trackChanges);
            var mappedEntity = _mapper.Map<VehicleType>(entity);
            _manager.VehicleTypeRepository.DeleteOneVehicleType(mappedEntity);
            await _manager.SaveChanges();
        }

        public async Task<IEnumerable<VehicleTypeDto>> GetAllVehicleTypesAsync(bool trackChanges)
        {
            var entities = await _manager.VehicleTypeRepository.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<VehicleTypeDto>>(entities);
        }

        public async Task<VehicleTypeDto> GetOneVehicleTypeAsync(int id, bool trackChanges)
        {
            var entity = await _manager.VehicleTypeRepository.GetByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"VehicleTpe with id : {id} could not found");
            }
            return _mapper.Map<VehicleTypeDto>(entity);
        }

        public async Task UpdateOneVehicleTypeAsync(int id, VehicleTypeDto vehicleType, bool trackChanges)
        {
            var entity = await GetOneVehicleTypeAsync(id, trackChanges);

            if (vehicleType == null)
            {
                throw new ArgumentNullException(nameof(vehicleType));
            }

            var mappedEntity = _mapper.Map<VehicleType>(vehicleType);

            var validator = new VehicleTypeValidator();
            var result = validator.Validate(mappedEntity);
            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage;
                throw new ArgumentException(errorMessage, nameof(vehicleType));
            }

            var entities = await GetAllVehicleTypesAsync(false);
            foreach (var item in entities)
            {
                if (item.TypeName == mappedEntity.TypeName)
                {
                    throw new Exception("TypeName must be uniq");
                }
            }

            _manager.VehicleTypeRepository.UpdateOneVehicleType(mappedEntity);
            await _manager.SaveChanges();
        }
    }
}
