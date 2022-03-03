using System.ComponentModel.DataAnnotations;
namespace Aspire.Models
{
    public class UserAuthentication
    {
        [Key]
        [EmailAddress]
        public string EmailId { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
        public string Password { get; set; }
    }
}
