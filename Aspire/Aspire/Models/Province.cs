using System.ComponentModel.DataAnnotations;

namespace Aspire.Models
{
    public class Province
    {
        [Key]
        [StringLength(2)]
        public string ProvinceInitials { get; set; }
        public string ProvinceName { get; set; }
    }
}
