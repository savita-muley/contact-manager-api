using System.ComponentModel.DataAnnotations;

namespace ContactManagement.API.DataAccess.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
