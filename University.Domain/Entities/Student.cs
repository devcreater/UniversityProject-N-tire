namespace University.Domain.Entities
{
    public class Student : Auditable
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public int Course { get; set; }

        public string Faculty { get; set; }


    }
}
