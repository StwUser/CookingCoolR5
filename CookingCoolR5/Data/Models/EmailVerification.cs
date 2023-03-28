using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingCoolR5.Data.Models
{
    
    [Table("EmailVerifications")]
    public class EmailVerification
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string VerificationCode { get; set; }
    }
}
