using Application.Entities;
using Application.Features.Teams;
using Application.Interfaces;
using Moq;
using Shared.Features.Teams;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Features.Teams
{
    public class TeamServiceFixture
    {
        private readonly Mock<ITeamRepository> _mockRepository;
        private readonly ITeamService _systemUnderTest;
        public TeamServiceFixture()
        {
            _mockRepository = new Mock<ITeamRepository>();
            _mockRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Team { Id = 1, Name = "Test Team" });
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(new Team[] { new Team { Id = 1, Name = "Test Team" } });
            _systemUnderTest = new TeamService(_mockRepository.Object, new TeamAdapter());
        }

        [Fact]
        public async Task Get_Team_Async_Should_Call_Repository()
        {
            var team = await _systemUnderTest.GetTeamAsync(new GetTeamQuery { Id = 1 });
            Assert.NotNull(team);
            _mockRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once,
                $"{nameof(TeamService)} should call {nameof(ITeamRepository)} during method {nameof(TeamService.GetTeamAsync)}");
        }

        [Fact]
        public async Task Get_Teams_Async_Should_Call_Repository()
        {
            var teams = await _systemUnderTest.GetAllTeamsAsync(new GetAllTeamsQuery { });
            Assert.NotNull(teams);
            Assert.NotEmpty(teams);
            _mockRepository.Verify(x => x.GetAllAsync(), Times.Once, 
                $"{nameof(TeamService)} should call {nameof(ITeamRepository)} during method {nameof(TeamService.GetAllTeamsAsync)}");
        }

        [Fact]
        public async Task Update_Team_Async_Should_Call_Repository()
        {
            await _systemUnderTest.UpdateTeamAsync(new UpdateTeamCommand { Name = "Team update!" });
            _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<Team>()), Times.Once, 
                $"{nameof(TeamService)} should call {nameof(ITeamRepository)} during method {nameof(TeamService.UpdateTeamAsync)}");
        }

        [Fact]
        public async Task Add_Team_Async_Should_Call_Repository()
        {
            var team = await _systemUnderTest.AddTeamAsync(new AddTeamCommand { Name = "Team add"});
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<Team>()), Times.Once,
                $"{nameof(TeamService)} should call {nameof(ITeamRepository)} during method {nameof(TeamService.AddTeamAsync)}");
        }
    }
}
