using Application.Entities;
using Application.Features.VotingActions;
using Application.Interfaces;
using Moq;
using Shared.Features.VotingAction;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Features.VotingActions
{
    public class VotingActionServiceFixture
    {
        private readonly Mock<IVotingActionRepository> _mockRepository;
        private readonly VotingActionService _systemUnderTest;
        public VotingActionServiceFixture()
        {
            _mockRepository = new Mock<IVotingActionRepository>();
            _systemUnderTest = new VotingActionService(_mockRepository.Object, new VotingActionAdapter());
        }

        [Fact]
        public async Task Add_Voting_Action_Should_Call_Repository()
        {
            var votingAction = await _systemUnderTest.AddVotingActionAsync(new AddVotingActionCommand());
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<VotingAction>()), Times.Once,
                $"{nameof(IVotingActionService)} should call {nameof(IVotingActionRepository)} during method {nameof(IVotingActionService.AddVotingActionAsync)}");
        }
    }
}
