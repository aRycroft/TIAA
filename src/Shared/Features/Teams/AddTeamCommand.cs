namespace Shared.Features.Teams
{
    public class AddTeamCommand
    {
        public AddTeamCommand()
        {
            Name = string.Empty;
        }

        public string Name { get; set; }
    }
}
