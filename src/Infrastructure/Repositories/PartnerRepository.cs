using Application.Entities;
using Application.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class PartnerRepository : CrudRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
