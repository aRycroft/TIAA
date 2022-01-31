using Application.Interfaces;
using Shared.Features.Teams;

namespace Application.Features.Partners
{
    public class MovePartnerToTeamHandler : IMovePartnerToTeamHandler
    {
        private readonly IPartnerRepository _partnerRepository;

        public MovePartnerToTeamHandler(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public async Task MovePartnerToTeam(MovePartnerToTeamCommand command)
        {
            var entity = await _partnerRepository.GetAsync(command.PartnerId);

            entity.TeamId = command.TeamId;

            await _partnerRepository.UpdateAsync(entity);
        }
    }

    public interface IMovePartnerToTeamHandler
    {
        Task MovePartnerToTeam(MovePartnerToTeamCommand command);
    }
}
