using Api.Controllers;
using Application.Features.Teams;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shared.Features.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.UnitTests.Controllers
{
    public class TeamControllerFixture
    {
        private Mock<ITeamService> _mockTeamService;
        private TeamController _systemUnderTest;

        public TeamControllerFixture()
        {
            _mockTeamService = new Mock<ITeamService>();

            _mockTeamService.Setup(x => x.GetAllTeamsAsync(It.IsAny<GetAllTeamsQuery>()))
                .ReturnsAsync(new List<TeamDto> { new TeamDto { } });
            _mockTeamService.Setup(x => x.GetTeamAsync(It.IsAny<GetTeamQuery>()))
                .ReturnsAsync(new TeamDto { } );

            _systemUnderTest = new TeamController(_mockTeamService.Object);
        }

        [Fact]
        public async Task Get_All_Returns_Valid_Result()
        {
            await ControllerTestMethods.AssertControllerMethodReturnsExpectedAndCallsService<OkObjectResult, IEnumerable<TeamDto>>(
                () => _systemUnderTest.GetAll(new GetAllTeamsQuery()),
                () => _mockTeamService.Verify(x => x.GetAllTeamsAsync(It.IsAny<GetAllTeamsQuery>()), Times.Once(),
                    $"{nameof(TeamController.GetAll)} should call partner service once."));
        }

        [Fact]
        public async Task Get_Returns_Valid_Result()
        {
            await ControllerTestMethods.AssertControllerMethodReturnsExpectedAndCallsService<OkObjectResult, TeamDto>(
                () => _systemUnderTest.Get(new GetTeamQuery()),
                () => _mockTeamService.Verify(x => x.GetTeamAsync(It.IsAny<GetTeamQuery>()), Times.Once(),
                    $"{nameof(TeamController.Get)} should call partner service once."));
        }
    }
}
