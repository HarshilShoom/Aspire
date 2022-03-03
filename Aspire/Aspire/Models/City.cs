using System.ComponentModel.DataAnnotations;
namespace Aspire.Models
{
    public class City
    {
        [key]
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
