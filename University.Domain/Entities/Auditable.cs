using System;

namespace University.Domain.Entities
{
    public class Auditable
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
