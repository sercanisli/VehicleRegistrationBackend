using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase 
    {
        private readonly IServiceManager _manager;

        public VehiclesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAllVehiclesAsync")]
        public async Task<IActionResult> GetAllVehiclesAsync()
        {
            try
            {
                var entities = await _manager.VehicleService.GetAllVehiclesAsync(false);
                return Ok(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAllVehiclesWithDetailsAsync()
        {
            return Ok(await _manager.VehicleService.GetAllVehiclesWithDetailsAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneVehicleAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
                var entity = await _manager.VehicleService.GetOneVehicleAsync(id, false);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneVehicleAsync([FromBody] VehicleDto vehicle)
        {
            try
            {
                await _manager.VehicleService.CreateOneVehicleAsync(vehicle);
                return StatusCode(201, vehicle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneVehicleAsync([FromRoute(Name = "id")]int id, [FromBody] VehicleDto vehicle)
        {
            try
            {
                await _manager.VehicleService.UpdateOneVehicleAsync(id, vehicle, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneVehicleAsync([FromRoute(Name = "id")] int id)
        {
            try
            {
                await _manager.VehicleService.DeleteOneVehicleAsync(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
