namespace RegisterWeb.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int OccupationId { get; set; }
        public Occupation? Occupation { get; set; }
    }
}