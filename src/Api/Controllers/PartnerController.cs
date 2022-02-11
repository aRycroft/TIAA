using Application.Features.Partners;
using Microsoft.AspNetCore.Mvc;
using Shared.Features.Partners;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;
        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet, Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPartnersQuery query)
        {
            return Ok(await _partnerService.GetAllPartnersAsync(query));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPartnerQuery query)
        {
            return Ok(await _partnerService.GetPartnerAsync(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPartnerCommand command)
        {
            return Ok(await _partnerService.AddPartnerAsync(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePartnerCommand command)
        {
            await _partnerService.UpdatePartnerAsync(command);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> MovePartnerToTeam([FromServices] IMovePartnerToTeamHandler handler, MovePartnerToTeamCommand command)
        {
            await handler.MovePartnerToTeam(command);
            return Ok();
        }

    }
}
