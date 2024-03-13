using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BrandsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllBrandsAsync")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            try
            {
                var entities = await _manager.BrandService.GetAllBrandsAsync(false);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBrandAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = await _manager.BrandService.GetOneBrandAsync(id, false);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneBrandAsync([FromBody] BrandDto brand)
        {
            try
            {
                await _manager.BrandService.CreateOneBrandAsync(brand);
                return StatusCode(201, brand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBrandAsync([FromRoute(Name = "id")] int id, [FromBody] BrandDto brand)
        {
            try
            {
                await _manager.BrandService.UpdateOneBrandAsync(id, brand, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBrandAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
                await _manager.BrandService.DeleteOneBrandAsync(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
