namespace Application.Entities
{
    public class Partner
    {
        public Partner()
        {
            Name = string.Empty;    
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Team Team { get; set; }
    }
}
