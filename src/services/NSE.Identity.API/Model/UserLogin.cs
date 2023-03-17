using System.ComponentModel.DataAnnotations;

namespace NSE.Identity.API.Model
{
    public class UserLogin
    {
        [Required(ErrorMessage = "The field {0} is required.")]
        [EmailAddress(ErrorMessage = "The field {0} is in format invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must have between 2 and 1 characters.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
