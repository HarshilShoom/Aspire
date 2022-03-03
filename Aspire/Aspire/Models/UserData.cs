using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspire.Models
{
    public class UserData
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime JoiningDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
        
        [ForeignKey("EducationId")]
        public int EducationId { get; set; }
        public UserEducation? Education { get; set; }


        [ForeignKey("EmailId")]
        public string EmailId { get; set; }
        public UserAuthentication? UserAuthentication { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public UserAddress? Address { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public UserRole? Role { get; set; }
    }
}
