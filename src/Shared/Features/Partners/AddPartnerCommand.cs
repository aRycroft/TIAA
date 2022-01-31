namespace Shared.Features.Partners
{
    public class AddPartnerCommand
    {
        public AddPartnerCommand()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
    }
}
