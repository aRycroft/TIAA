namespace Shared.Features.Teams
{
    public class TeamDto
    {
        public TeamDto()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
