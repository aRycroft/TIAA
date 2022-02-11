using Application.Entities;
using Application.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class TeamRepository : CrudRepository<Team>, ITeamRepository
    {
        public TeamRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
