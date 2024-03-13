using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Services.Contracts;
using Services.ValidationRules.FluentValidation;

namespace Services.Concretes
{
    public class VehicleManager : IVehicleService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
         
        public VehicleManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<VehicleDto> CreateOneVehicleAsync(VehicleDto vehicle)
        {
            if(vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            var entities = await _manager.VehicleRepository.GetAllAsync(false);
            foreach (var item in entities)
            {
                if (item.Plate == vehicle.Plate)
                {
                    throw new Exception("Plate must be uniq");
                }
            }

            var entity = _mapper.Map<Vehicle>(vehicle);

            var validator = new VehicleValidator();
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage; 
                throw new ArgumentException(errorMessage, nameof(vehicle));
            }

            _manager.VehicleRepository.CreateOneVehicle(entity);
            await _manager.SaveChanges();
            return _mapper.Map<VehicleDto>(entity);
        }

        public async Task DeleteOneVehicleAsync(int id, bool trackChanges)
        {
            var entity = await _manager.VehicleRepository.GetByIdAsync(id, trackChanges);
            if(entity == null)
            {
                throw new Exception($"Vehicle with id : {id} could not found");
            }
            _manager.VehicleRepository.DeleteOneVehicle(entity);
            await _manager.SaveChanges();
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync(bool trackChanges)
        {
            return await _manager.VehicleRepository.GetAllAsync(trackChanges);
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesWithDetailsAsync(bool trackChanges)
        {
            return await _manager.VehicleRepository.GetAllVehilesWithDetailsAsync(trackChanges);
        }

        public async Task<VehicleDto> GetOneVehicleAsync(int id, bool trackChanges)
        {
            var entity = await _manager.VehicleRepository.GetByIdAsync(id,trackChanges);
            if (entity == null)
            {
                throw new Exception($"Vehicle with id : {id} could not found");
            }
            return _mapper.Map<VehicleDto>(entity);
        }

        public async Task UpdateOneVehicleAsync(int id, VehicleDto vehicle, bool trackChanges)
        {
            var entity = await _manager.VehicleRepository.GetByIdAsync(id, trackChanges);

            if (entity == null)
            {
                throw new Exception($"Vehicle with id : {id} could not found");
            }

            if(vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }

            var entities = await _manager.VehicleRepository.GetAllAsync(false);
            foreach (var item in entities)
            {
                if (item.Plate == vehicle.Plate)
                {
                    throw new Exception("Plate must be uniq");
                }
            }

            var mappedEntity = _mapper.Map<Vehicle>(vehicle);

            var validator = new VehicleValidator();
            var result = validator.Validate(mappedEntity);
            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage;
                throw new ArgumentException(errorMessage, nameof(vehicle));
            }

            _manager.VehicleRepository.UpdateOneVehicle(mappedEntity);
            await _manager.SaveChanges();
        }
    }
}
