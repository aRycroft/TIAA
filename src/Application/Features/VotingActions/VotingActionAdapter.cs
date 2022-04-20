using Application.Entities;
using Shared.Features.VotingAction;

namespace Application.Features.VotingActions
{
    public class VotingActionAdapter : IVotingActionAdapter
    {
        public VotingAction EntityFromAddCommand(AddVotingActionCommand command)
        {
            return new VotingAction
            {
                VotingActionType = command.VotingActionType
            };
        }
    }

    public interface IVotingActionAdapter
    {
        VotingAction EntityFromAddCommand(AddVotingActionCommand command);
    }
}
