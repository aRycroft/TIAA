using Application.Features.Teams;
using Microsoft.AspNetCore.Mvc;
using Shared.Features.Teams;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTeamsQuery query)
        {
            return Ok(await _teamService.GetAllTeamsAsync(query));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTeamQuery query)
        {
            return Ok(await _teamService.GetTeamAsync(query));
        }
    }
}
