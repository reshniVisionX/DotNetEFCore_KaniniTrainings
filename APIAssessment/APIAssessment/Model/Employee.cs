using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAssessment.Model
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
       
        [ForeignKey("Department")]
        public int? depId { get; set; }
        [Required, MaxLength(50)]
        public string empName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string? role { get; set; }

        public ICollection<Project>? projects { get; set; }

     
    }
}
