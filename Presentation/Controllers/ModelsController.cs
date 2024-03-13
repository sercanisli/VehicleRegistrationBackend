using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/models")]
    public class ModelsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ModelsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllModelsAsync")]
        public async Task<IActionResult> GetAllModelsAsync()
        {
            try
            {
                var entities = await _manager.ModelService.GetAllModelsAsync(false);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetAllModelsWithDetailsAsync()
        {
            return Ok(await _manager.ModelService.GetAllModelsWithDetailsAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneModelAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = await _manager.ModelService.GetOneModelAsync(id, false);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneModelAsync([FromBody] ModelDto model)
        {
            try
            {
                await _manager.ModelService.CreateOneModelAsync(model);
                return StatusCode(201, model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBrandAsync([FromRoute(Name = "id")] int id, [FromBody] ModelDto model)
        {
            try
            {
                await _manager.ModelService.UpdateOneModelAsync(id, model, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneModelAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
               await _manager.ModelService.DeleteOneModelAsync(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
