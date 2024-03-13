using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/vehicletypes")]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public VehicleTypesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllVehicleTypesAsync")]
        public async Task<IActionResult> GetAllVehicleTypesAsync()
        {
            try
            {
                var entities = await _manager.VehicleTypeService.GetAllVehicleTypesAsync(false);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneVehicleTypeAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = await _manager.VehicleTypeService.GetOneVehicleTypeAsync(id, false);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneVehicleTypeAsync([FromBody] VehicleTypeDto vehicleType)
        {
            try
            {
                await _manager.VehicleTypeService.CreateOneVehicleTypeAsync(vehicleType);
                return StatusCode(201, vehicleType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneVehicleTypeAsync([FromRoute(Name = "id")] int id, [FromBody] VehicleTypeDto vehicleType)
        {
            try
            {
                await _manager.VehicleTypeService.UpdateOneVehicleTypeAsync(id, vehicleType, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneVehicleTypeAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
                await _manager.VehicleTypeService.DeleteOneVehicleTypeAsync(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
