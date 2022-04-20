using Application.Entities;
using Application.Interfaces;
using Shared.Features.VotingAction;

namespace Application.Features.VotingActions
{
    public class VotingActionService : IVotingActionService
    {
        private readonly IVotingActionRepository _votingActionRepository;
        private readonly IVotingActionAdapter _votingActionAdapter;

        public VotingActionService(IVotingActionRepository votingActionRepository, IVotingActionAdapter votingActionAdapter)
        {
            _votingActionRepository = votingActionRepository;
            _votingActionAdapter = votingActionAdapter;
        }

        public async Task<VotingAction> AddVotingActionAsync(AddVotingActionCommand command)
        {
            return await _votingActionRepository.AddAsync(_votingActionAdapter.EntityFromAddCommand(command));
        }
    }

    public interface IVotingActionService
    {
        Task<VotingAction> AddVotingActionAsync(AddVotingActionCommand command);
    }
}
