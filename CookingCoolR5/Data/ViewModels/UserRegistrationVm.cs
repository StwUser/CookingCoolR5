using System.ComponentModel.DataAnnotations;

namespace CookingCoolR5.Data.ViewModels
{
    public class UserRegistrationVm
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Login { get; set; }
        [DataType(DataType.Password, ErrorMessage = "Password is not valid")]
        public string Password { get; set; }
    }
}
