using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_MVC_CodeFirst.Models
{
    public class Students
    {
        [Key]
        public int studId { get; set; }
        public string studName { get; set; }    
        public string dept { get; set; }
        // set navigation property to set relationship with Items
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Items items { get; set; }

    }
}
