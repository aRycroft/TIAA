using Application.Entities;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        public Task<Partner> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Partner[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        
        public Task<Partner> AddAsync(Partner entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Partner entity)
        {
            throw new NotImplementedException();
        }
    }
}
