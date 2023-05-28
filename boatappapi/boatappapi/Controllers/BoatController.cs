using boatappapi.Middleware;
using boatappapi.Model;
using boatappapi.Service.Boat;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace boatappapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private IBoatService _boatService;
        public BoatController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetBoats()
        {
            var boats = _boatService.GetBoats();

            return Ok(boats);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBoatById(string id)
        {
            var isGuid = Guid.TryParse(id, out var guid);
            if (!isGuid)
                return BadRequest("failed to find id");

            var boat = _boatService.GetBoatById(guid);

            if (boat == null)
                return BadRequest("failed to find id");

            return Ok(boat);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddBoat([FromBody] BoatModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid inputs");

            var response = _boatService.AddBoat(model);

            if (!response.Success)
                return StatusCode(500, response);

            return Ok(response);
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateBoat([FromBody] BoatModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid inputs");

            var response = _boatService.UpdateBoat(model);

            if (!response.Success)
                return StatusCode(500, response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteBoat(string id)
        {
            var isGuid = Guid.TryParse(id, out var guid);

            if (!isGuid)
                return BadRequest("failed to find id");

            var response = _boatService.DeleteBoat(guid);

            if (!response.Success)
                return StatusCode(500, response);

            return Ok(response);
        }
    }
}
