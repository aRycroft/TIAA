using Application.Entities;
using Shared.Features.Partners;

namespace Application.Features.Partners
{
    public class PartnerAdapter : IPartnerAdapter
    {
        public PartnerDto DtoFromEntity(Partner partner)
        {
            return new PartnerDto
            {
                Name = partner.Name
            };
        }

        public Partner EntityFromAddCommand(AddPartnerCommand command)
        {
            return new Partner
            {
                Name = command.Name
            };
        }

        public Partner EntityFromUpdateCommand(UpdatePartnerCommand command)
        {
            return new Partner
            { 
                Id = command.Id, 
                Name = command.Name 
            };
        }
    }

    public interface IPartnerAdapter 
    {
        public PartnerDto DtoFromEntity(Partner partner);
        public Partner EntityFromAddCommand(AddPartnerCommand command);
        public Partner EntityFromUpdateCommand(UpdatePartnerCommand command);
    }
}
