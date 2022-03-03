using System.ComponentModel.DataAnnotations;

namespace Aspire.Models
{
    public class EducationLevel
    {
        [Key]
        public int LevelId { get; set; }
        public string Name { get; set; }
    }
}
