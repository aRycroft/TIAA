﻿using Application.Features.Partners;
using Microsoft.AspNetCore.Mvc;
using Shared.Features.Partners;
using Shared.Features.Teams;

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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPartnersQuery query)
        {
            return Ok(await _partnerService.GetAllPartnersAsync(query));
        }

        [HttpPatch]
        public async Task<IActionResult> MovePartnerToTeam([FromServices] IMovePartnerToTeamHandler handler, MovePartnerToTeamCommand command)
        {
            await handler.MovePartnerToTeam(command);
            return Ok();
        }

    }
}