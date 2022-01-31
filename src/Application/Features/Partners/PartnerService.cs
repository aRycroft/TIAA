using Application.Entities;
using Application.Interfaces;
using Shared.Features.Partners;

namespace Application.Features.Partners
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IPartnerAdapter _partnerAdapter;

        public PartnerService(IPartnerRepository partnerRepository, IPartnerAdapter partnerAdapter)
        {
            _partnerRepository = partnerRepository;
            _partnerAdapter = partnerAdapter;
        }

        public async Task<PartnerDto> GetPartnerAsync(GetPartnerQuery query)
        {
            var entity = await _partnerRepository.GetAsync(query.Id);
            return _partnerAdapter.DtoFromEntity(entity);
        }
     
        public async Task<IEnumerable<PartnerDto>> GetAllPartnersAsync(GetAllPartnersQuery query)
        {
            var entites = await _partnerRepository.GetAllAsync();
            return entites.Select(_partnerAdapter.DtoFromEntity);
        }
        
        public async Task<Partner> AddPartnerAsync(AddPartnerCommand command)
        {
            var entity = await _partnerRepository.AddAsync(_partnerAdapter.EntityFromAddCommand(command));
            return entity;
        }

        public async Task UpdatePartnerAsync(UpdatePartnerCommand command)
        {
            await _partnerRepository.UpdateAsync(_partnerAdapter.EntityFromUpdateCommand(command));
        }
    }

    public interface IPartnerService
    {
        Task<PartnerDto> GetPartnerAsync(GetPartnerQuery query);
        Task<IEnumerable<PartnerDto>> GetAllPartnersAsync(GetAllPartnersQuery query);
        Task<Partner> AddPartnerAsync(AddPartnerCommand command);
        Task UpdatePartnerAsync(UpdatePartnerCommand command);
    }
}
