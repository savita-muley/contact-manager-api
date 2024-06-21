using System.ComponentModel.DataAnnotations;

namespace ContactManagement.API.Models.Request
{
    public class CreateContactRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
    }
}