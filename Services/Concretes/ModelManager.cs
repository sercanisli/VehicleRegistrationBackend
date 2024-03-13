using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contract;
using Services.Contracts;
using Services.ValidationRules.FluentValidation;

namespace Services.Concretes
{
    public class ModelManager : IModelService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ModelManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ModelDto> CreateOneModelAsync(ModelDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var entity = _mapper.Map<Model>(model);

            var validator = new ModelValidator();
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage;
                throw new ArgumentException(errorMessage, nameof(model));
            }

            var entities = await _manager.ModelRepository.GetAllAsync(false);
            foreach (var item in entities)
            {
                if(item.ModelName==entity.ModelName && item.ModelYear==entity.ModelYear)
                {
                    throw new Exception("This car model already exists");
                }
            }

            _manager.ModelRepository.CreateOneModel(entity);
            await _manager.SaveChanges();
            return _mapper.Map<ModelDto>(entity);
        }

        public async Task DeleteOneModelAsync(int id, bool trackChanges)
        {
            var entity = await _manager.ModelRepository.GetByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Vehicle with id : {id} could not found");
            }
            _manager.ModelRepository.DeleteOneModel(entity);
            await _manager.SaveChanges();
        }

        public async Task<IEnumerable<ModelDto>> GetAllModelsAsync(bool trackChanges)
        {
            var entities = await _manager.ModelRepository.GetAllAsync(trackChanges);
            return _mapper.Map<IEnumerable<ModelDto>>(entities);
        }

        public async Task<IEnumerable<Model>> GetAllModelsWithDetailsAsync(bool trackChanges)
        {
            return await _manager.ModelRepository.GetAllModelsWithDetailsAsync(trackChanges);
        }

        public async Task<ModelDto> GetOneModelAsync(int id, bool trackChanges)
        {
            var entity = await _manager.ModelRepository.GetByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Vehicle with id : {id} could not found");
            }
            return _mapper.Map<ModelDto>(entity);
        }

        public async Task UpdateOneModelAsync(int id, ModelDto model, bool trackChanges)
        {
            var entity = await _manager.ModelRepository.GetByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Vehicle with id : {id} could not found");
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var mappedEntity = _mapper.Map<Model>(model);

            var validator = new ModelValidator();
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.First().ErrorMessage;
                throw new ArgumentException(errorMessage, nameof(model));
            }

            var entities = await _manager.ModelRepository.GetAllAsync(false);
            foreach (var item in entities)
            {
                if (item.ModelName == entity.ModelName && item.ModelYear == entity.ModelYear)
                {
                    throw new Exception("This car model already exists");
                }
            }

            _manager.ModelRepository.UpdateOneModel(mappedEntity);
            await _manager.SaveChanges();
        }
    }
}
