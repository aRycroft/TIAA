using Application.Entities;
using Application.Features.Partners;
using Application.Interfaces;
using Moq;
using Shared.Features.Partners;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Features.Partners
{
    public class PartnerServiceFixture
    {
        private readonly Mock<IPartnerRepository> _mockRepository;
        private readonly IPartnerService _systemUnderTest;

        public PartnerServiceFixture()
        {
            _mockRepository = new Mock<IPartnerRepository>();
            _mockRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Partner { Id = 1, Name = "Test partner." });
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(new Partner[] { new Partner { Id = 1, Name = "Test partner." } });
            _systemUnderTest = new PartnerService(_mockRepository.Object, new PartnerAdapter());
        }

        [Fact]
        public async Task Get_Partner_Async_Should_Call_Repository()
        {
            var partner = await _systemUnderTest.GetPartnerAsync(new GetPartnerQuery{ Id = 1 });
            Assert.NotNull(partner);
            _mockRepository.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once,
                $"{nameof(PartnerService)} should call {nameof(IPartnerRepository)} during method {nameof(PartnerService.GetPartnerAsync)}");
        }

        [Fact]
        public async Task Get_Partners_Async_Should_Call_Repository()
        {
            var partners = await _systemUnderTest.GetAllPartnersAsync(new GetAllPartnersQuery{ });
            Assert.NotNull(partners);
            Assert.NotEmpty(partners);
            _mockRepository.Verify(x => x.GetAllAsync(), Times.Once,
                $"{nameof(PartnerService)} should call {nameof(IPartnerRepository)} during method {nameof(PartnerService.GetAllPartnersAsync)}");
        }

        [Fact]
        public async Task Update_Partner_Async_Should_Call_Repository()
        {
            await _systemUnderTest.UpdatePartnerAsync(new UpdatePartnerCommand{ Id = 1, Name = "Team update!" });
            _mockRepository.Verify(x => x.UpdateAsync(It.IsAny<Partner>()), Times.Once,
                $"{nameof(PartnerService)} should call {nameof(IPartnerRepository)} during method {nameof(PartnerService.GetAllPartnersAsync)}");
        }

        [Fact]
        public async Task Add_Partner_Async_Should_Call_Repository()
        {
            var team = await _systemUnderTest.AddPartnerAsync(new AddPartnerCommand{ Name = "Team add" });
            _mockRepository.Verify(x => x.AddAsync(It.IsAny<Partner>()), Times.Once,
                $"{nameof(PartnerService)} should call {nameof(IPartnerRepository)} during method {nameof(PartnerService.GetAllPartnersAsync)}");
        }
    }
}
