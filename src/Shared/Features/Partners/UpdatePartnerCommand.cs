namespace Shared.Features.Partners
{
    public class UpdatePartnerCommand
    {
        public UpdatePartnerCommand()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
