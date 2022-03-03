using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aspire.Models
{
    public class UserAddress
    {
        [Key]
        public string AddressId { get; set;}
        public string Address { get; set; }
        [RegularExpression(@"[A-Z][0-9][A-Z](\s|-)[0-9][A-Z][0-9]")]
        public string PostalCode { get; set; }

        [ForeignKey("CityId")]
        public string CityId { get; set; }
        public City? City { get; set; }

        [ForeignKey("ProvinceInitials")]
        public string ProvinceInitials { get; set; }
        public Province? Province { get; set; }
    }
}
