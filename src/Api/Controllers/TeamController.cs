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

        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTeamsQuery query)
        {
            return Ok(await _teamService.GetAllTeamsAsync(query));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTeamQuery query)
        {
            return Ok(await _teamService.GetTeamAsync(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTeamCommand command)
        {
            return Ok(await _teamService.AddTeamAsync(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTeamCommand command)
        {
            await _teamService.UpdateTeamAsync(command);
            return Ok();
        }
    }
}
