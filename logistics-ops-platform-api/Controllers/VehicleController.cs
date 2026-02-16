using Logistics.Application.DTOs;
using Logistics.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace logistics_ops_platform_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("CreateVehicle")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateVehicle(CreateVehicleDto vehicle)
        {
            var res = await _vehicleService.CreateAsync(vehicle);
            return Ok(res);
        }

        [HttpGet("GetVehicles")]
        public async Task<IActionResult> GetAllVehicle([FromQuery] VehicleFilter filter)
        {
            var res = await _vehicleService.GetAllAsync(filter);
            return Ok(res);
        }

        [HttpGet("GetVehicleById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res = await _vehicleService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPut("UpdateVehicle/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateVehicle(Guid id, VehicleDto vehicle)
        {
            var res = await _vehicleService.UpdateAsync(id, vehicle);
            return Ok(res);
        }

        [HttpDelete("DeleteVehicle/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteVehicle(Guid id)
        {
            var res = await _vehicleService.DeleteAsync(id);
            return Ok(res);
        }
    }
}
