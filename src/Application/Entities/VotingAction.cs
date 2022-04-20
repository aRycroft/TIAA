using Shared.Features.VotingAction;

namespace Application.Entities
{
    public class VotingAction
    {
        public int Id { get; set; }
        public VotingActionType VotingActionType { get; set; }
    }
}
