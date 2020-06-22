using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength=4, ErrorMessage = "Password must be longer than 4 and shorter than 8 digits")]
        public string Password { get; set; }
    }
}