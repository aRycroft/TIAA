using Application.Entities;
using Application.Interfaces;
using Shared.Features.Teams;

namespace Application.Features.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamAdapter _teamAdapter;

        public TeamService(ITeamRepository teamRepository, ITeamAdapter teamAdapter)
        {
            _teamRepository = teamRepository;
            _teamAdapter = teamAdapter;
        }

        public async Task<TeamDto> GetTeamAsync(GetTeamQuery query)
        {
            var entity = await _teamRepository.GetAsync(query.Id);
            return _teamAdapter.DtoFromEntity(entity);
        }

        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync(GetAllTeamsQuery query)
        {
            var entities = await _teamRepository.GetAllAsync();
            return entities.Select(_teamAdapter.DtoFromEntity);
        }

        public async Task<Team> AddTeamAsync(AddTeamCommand command)
        {
            return await _teamRepository.AddAsync(_teamAdapter.EntityFromAddCommand(command));
        }

        public async Task UpdateTeamAsync(UpdateTeamCommand command)
        {
            await _teamRepository.UpdateAsync(_teamAdapter.EntityFromUpdateCommand(command));
        }
    }

    public interface ITeamService
    {
        Task<TeamDto> GetTeamAsync(GetTeamQuery query);
        Task<IEnumerable<TeamDto>> GetAllTeamsAsync(GetAllTeamsQuery query);
        Task<Team> AddTeamAsync(AddTeamCommand command);
        Task UpdateTeamAsync(UpdateTeamCommand command);
    }
}
