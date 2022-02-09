using Api.Controllers;
using Application.Features.Partners;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shared.Features.Partners;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.UnitTests.Controllers
{
    public class PartnerControllerFixture
    {
        private Mock<IPartnerService> _mockPartnerService;
        private PartnerController _systemUnderTest;

        public PartnerControllerFixture()
        {
            _mockPartnerService = new Mock<IPartnerService>();

            _mockPartnerService.Setup(x => x.GetAllPartnersAsync(It.IsAny<GetAllPartnersQuery>()))
                .ReturnsAsync(new List<PartnerDto> { new PartnerDto { } });
            _mockPartnerService.Setup(x => x.GetPartnerAsync(It.IsAny<GetPartnerQuery>()))
                .ReturnsAsync(new PartnerDto { });

            _systemUnderTest = new PartnerController(_mockPartnerService.Object);
        }

        [Fact]
        public async Task Get_All_Returns_Valid_Result()
        {
            await ControllerTestMethods.AssertControllerMethodReturnsExpectedAndCallsService<OkObjectResult, IEnumerable<PartnerDto>>(
                () => _systemUnderTest.GetAll(new GetAllPartnersQuery()), 
                () => _mockPartnerService.Verify(x => x.GetAllPartnersAsync(It.IsAny<GetAllPartnersQuery>()), Times.Once(), 
                    $"{nameof(PartnerController.GetAll)} should call partner service once."));
        }

        [Fact]
        public async Task Get_Returns_Valid_Result()
        {
            await ControllerTestMethods.AssertControllerMethodReturnsExpectedAndCallsService<OkObjectResult, PartnerDto>(
                () => _systemUnderTest.Get(new GetPartnerQuery()), 
                () => _mockPartnerService.Verify(x => x.GetPartnerAsync(It.IsAny<GetPartnerQuery>()), Times.Once(), 
                    $"{nameof(PartnerController.Get)} should call partner service once."));
        }

        [Fact]
        public async Task Move_Partner_To_Team_Returns_Valid_Result()
        {
            var mockHandler = new Mock<IMovePartnerToTeamHandler>();
            await ControllerTestMethods.AssertControllerMethodReturnsExpectedAndCallsService<OkResult>(
                () => _systemUnderTest.MovePartnerToTeam(mockHandler.Object, new MovePartnerToTeamCommand()),
                () => mockHandler.Verify(x => x.MovePartnerToTeam(It.IsAny<MovePartnerToTeamCommand>()), Times.Once(),
                    $"{nameof(PartnerController.MovePartnerToTeam)} should call {nameof(IMovePartnerToTeamHandler.MovePartnerToTeam)} once."));
        }

    }
}
