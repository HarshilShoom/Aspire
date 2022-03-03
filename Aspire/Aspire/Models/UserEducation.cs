
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Aspire.Models
{
    public class UserEducation
    {
        [Key]
        public int UserEducationId { get; set; }

        public string InstitutionName { get; set; }

        [Range(4,4)]
        public int PassingYear { get; set; }


        [ForeignKey("HigestEducation")]
        public string HigestEducation { get; set; }
        public EducationLevel? EducationLevel { get; set; }
    }
}
