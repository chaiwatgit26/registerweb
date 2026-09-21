namespace RegisterWeb.Models
{
    public class Register
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public DateTime RegisterDate { get; set; }
        public Person? Person { get; set; }
    }
}