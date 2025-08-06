using System.ComponentModel.DataAnnotations;

namespace EFCore_MVC_CodeFirst.Models
{
    public class Students
    {
        [Key]
        public int studId { get; set; }
        public string studName { get; set; }    
        public string dept { get; set; }
    }
}
