namespace Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Name = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
