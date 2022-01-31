using Application.Entities;
using Shared.Features.Teams;

namespace Application.Features.Teams
{
    public class TeamAdapter : ITeamAdapter
    {
        public TeamDto DtoFromEntity(Team team)
        {
            return new TeamDto
            {
                Name = team.Name
            };
        }

        public Team EntityFromAddCommand(AddTeamCommand command)
        {
            return new Team
            {
                Name = command.Name
            };
        }

        public Team EntityFromUpdateCommand(UpdateTeamCommand command)
        {
            return new Team 
            { 
                Id = command.Id, 
                Name = command.Name 
            };
        }
    }

    public interface ITeamAdapter
    {
        TeamDto DtoFromEntity(Team team);
        Team EntityFromAddCommand(AddTeamCommand command);
        Team EntityFromUpdateCommand(UpdateTeamCommand command);
    }
}
