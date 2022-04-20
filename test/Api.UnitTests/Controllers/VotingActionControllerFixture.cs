using Api.Controllers;
using Application.Entities;
using Application.Features.VotingActions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shared.Features.VotingAction;
using System.Threading.Tasks;
using Xunit;

namespace Api.UnitTests.Controllers
{
    public class VotingActionControllerFixture
    {
        private Mock<IVotingActionService> _mockService;
        private VotingActionController _systemUnderTest;

        public VotingActionControllerFixture()
        {
            _mockService = new Mock<IVotingActionService>();

            _mockService.Setup(x => x.AddVotingActionAsync(It.IsAny<AddVotingActionCommand>()))
                .ReturnsAsync(new VotingAction());

            _systemUnderTest = new VotingActionController(_mockService.Object);
        }

        [Fact]
        public async Task Post_Returns_Valid_Result()
        {
            await ControllerTestMethods.AssertControllerMethodReturnsExpectedAndCallsService<OkObjectResult, VotingAction>(
                () => _systemUnderTest.Post(new AddVotingActionCommand()),
                () => _mockService.Verify(x => x.AddVotingActionAsync(It.IsAny<AddVotingActionCommand>()), Times.Once(),
                    $"{nameof(VotingActionController.Post)} should call {nameof(VotingActionService.AddVotingActionAsync)} once."));
        }
    }
}
