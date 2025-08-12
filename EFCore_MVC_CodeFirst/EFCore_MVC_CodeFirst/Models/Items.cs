using System.ComponentModel.DataAnnotations;

namespace EFCore_MVC_CodeFirst.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public IList<Students> Students { get; set; } = new List<Students>();
    }
}
