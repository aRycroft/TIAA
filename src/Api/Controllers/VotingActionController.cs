using Application.Features.VotingActions;
using Microsoft.AspNetCore.Mvc;
using Shared.Features.VotingAction;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotingActionController : ControllerBase
    {
        private IVotingActionService _votingActionService;
        public VotingActionController(IVotingActionService votingActionService)
        {
            _votingActionService = votingActionService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddVotingActionCommand command)
        {
            return Ok(await _votingActionService.AddVotingActionAsync(command));
        }
    }
}
