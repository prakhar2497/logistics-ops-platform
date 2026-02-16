using Logistics.Application.Interfaces;
using Logistics.Application.Services;
using Logistics.Infrastructure.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace logistics_ops_platform_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataController : ControllerBase
    {
        private readonly IReferenceDataService _referenceDataService;
        public ReferenceDataController(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }
        // GET: api/<ReferenceDataController>
        [HttpGet("GetAllReferenceData")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllReferenceData()
        {
            var res = await _referenceDataService.GetAllReferenceDataAsync();
            return Ok(res);
        }

        // GET api/<ReferenceDataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReferenceDataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReferenceDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReferenceDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
