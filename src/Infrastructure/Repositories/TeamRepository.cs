using Application.Entities;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public Task<Team> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Team[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Team> AddAsync(Team entity)
        {
            throw new NotImplementedException();
        }

        public Task<Team> UpdateAsync(Team entity)
        {
            throw new NotImplementedException();
        }
    }
}
