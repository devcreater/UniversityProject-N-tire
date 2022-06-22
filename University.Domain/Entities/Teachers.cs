namespace University.Domain.Entities
{
    public class Teacher : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

    }
}
