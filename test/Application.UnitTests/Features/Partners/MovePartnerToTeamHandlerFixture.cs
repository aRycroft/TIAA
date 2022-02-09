using Application.Common.Exceptions;
using Application.Entities;
using Application.Features.Partners;
using Application.Interfaces;
using Moq;
using Shared.Features.Partners;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Features.Partners
{
    public class MovePartnerToTeamHandlerFixture
    {
        private readonly Mock<IPartnerRepository> _mockPartnerRepository;
        private readonly Mock<ITeamRepository> _mockTeamRepository;
        private readonly IMovePartnerToTeamHandler _systemUnderTest;

        public MovePartnerToTeamHandlerFixture()
        {
            _mockPartnerRepository = new Mock<IPartnerRepository>();
            _mockPartnerRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Partner { });
            _mockTeamRepository = new Mock<ITeamRepository>();
            _mockTeamRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Team { });
            _systemUnderTest = new MovePartnerToTeamHandler(_mockPartnerRepository.Object, _mockTeamRepository.Object);
        }

        [Fact]
        public async Task Handler_Should_Move_Partner_To_Team()
        {
            var movePartnerToTeamCommand = new MovePartnerToTeamCommand { PartnerId = 1, TeamId = 1};
            
            await _systemUnderTest.MovePartnerToTeam(movePartnerToTeamCommand);

            _mockPartnerRepository.Verify(x => x.UpdateAsync(It.IsAny<Partner>()), Times.Once,
                $"{nameof(MovePartnerToTeamHandler)} should call {nameof(IPartnerRepository.UpdateAsync)} " +
                $"during method {nameof(MovePartnerToTeamHandler.MovePartnerToTeam)}");
        }

        [Fact]
        public async Task Handler_Entity_Not_Found_Should_Throw_Exception()
        {
            _mockPartnerRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _systemUnderTest.MovePartnerToTeam(new MovePartnerToTeamCommand { }));
        }

        [Fact]
        public async Task Handler_Team_Not_Found_Should_Throw_Exception()
        {
            _mockTeamRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _systemUnderTest.MovePartnerToTeam(new MovePartnerToTeamCommand { }));
        }
    }
}
