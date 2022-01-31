namespace Shared.Features.Teams
{
    public class UpdateTeamCommand
    {
        public UpdateTeamCommand()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
