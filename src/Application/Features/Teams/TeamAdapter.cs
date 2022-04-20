using Application.Entities;
using Shared.Features.Teams;

namespace Application.Features.Teams
{
    public class TeamAdapter : ITeamAdapter
    {
        public TeamDto DtoFromEntity(Team team)
        {
            return team != null ? new TeamDto
            {
                Id = team.Id,
                Name = team.Name
            } 
            : new TeamDto();
        }

        public Team EntityFromAddCommand(AddTeamCommand command)
        {
            return command != null ? new Team
            {
                Name = command.Name
            } 
            : new Team();
        }

        public Team EntityFromUpdateCommand(UpdateTeamCommand command)
        {
            return command != null ? new Team 
            { 
                Id = command.Id, 
                Name = command.Name 
            }
            : new Team();
        }
    }

    public interface ITeamAdapter
    {
        TeamDto DtoFromEntity(Team team);
        Team EntityFromAddCommand(AddTeamCommand command);
        Team EntityFromUpdateCommand(UpdateTeamCommand command);
    }
}
