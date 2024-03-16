using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using FluentValidation;
using Repositories.Contract;
using Services.Contracts;
using Services.ValidationRules.FluentValidation;

namespace Services.Concretes
{
    public class BrandManager : IBrandService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public BrandManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<BrandDto> CreateOneBrandAsync(BrandDto brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }

            var entity = _mapper.Map<Brand>(brand);

            var validator = new BrandValidator();
            var result = validator.Validate(entity);
            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage;
                throw new ArgumentException(errorMessage, nameof(brand));
            }

            var entities = await GetAllBrandsAsync(false);
            foreach (var item in entities)
            {
                if (item.Name == entity.Name)
                {
                    throw new Exception("BrandName must be uniq");
                }
            }

            _manager.BrandRepository.CreateOneBrand(entity);
            await _manager.SaveChanges();
            return _mapper.Map<BrandDto>(entity);
        }

        public async Task DeleteOneBrandAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBrandAsync(id, trackChanges);
            var mappedEntity = _mapper.Map<Brand>(entity);
            _manager.BrandRepository.DeleteOneBrand(mappedEntity);
            await _manager.SaveChanges();
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync(bool trackChanges)
        {
            var entities = await _manager.BrandRepository.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<BrandDto>>(entities);
        }

        public async Task<BrandDto> GetOneBrandAsync(int id, bool trackChanges)
        {
            var entity = await _manager.BrandRepository.GetByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Brand with id : {id} could not found");
            }
            return _mapper.Map<BrandDto>(entity);
        }

        public async Task UpdateOneBrandAsync(int id, BrandDto brand, bool trackChanges)
        {
            var entity = await GetOneBrandAsync(id, trackChanges);
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }

            var mappedEntity = _mapper.Map<Brand>(brand);

            var validator = new BrandValidator();
            var result = validator.Validate(mappedEntity);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage;
                throw new ArgumentException(errorMessage, nameof(brand));
            }

            var entities = await GetAllBrandsAsync(false);
            foreach (var item in entities)
            {
                if (item.Name == mappedEntity.Name)
                {
                    throw new Exception("BrandName must be uniq");
                }
            }

            _manager.BrandRepository.UpdateOneBrand(mappedEntity);
            await _manager.SaveChanges();
        }
    }
}
