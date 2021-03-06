using Application.Common.Exceptions;
using Application.Interfaces;
using Shared.Features.Partners;

namespace Application.Features.Partners
{
    public class MovePartnerToTeamHandler : IMovePartnerToTeamHandler
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly ITeamRepository _teamRepository;

        public MovePartnerToTeamHandler(IPartnerRepository partnerRepository, ITeamRepository teamRepository)
        {
            _partnerRepository = partnerRepository;
            _teamRepository = teamRepository;
        }

        public async Task MovePartnerToTeam(MovePartnerToTeamCommand command)
        {
            var partner = await _partnerRepository.GetAsync(command.PartnerId) 
                ?? throw new EntityNotFoundException($"No partner exists with id {command.PartnerId}");

            var team = await _teamRepository.GetAsync(command.TeamId)
                ?? throw new EntityNotFoundException($"No team exists with id {command.TeamId}");

            partner.Team = team;

            await _partnerRepository.UpdateAsync(partner);
        }
    }

    public interface IMovePartnerToTeamHandler
    {
        Task MovePartnerToTeam(MovePartnerToTeamCommand command);
    }
}
