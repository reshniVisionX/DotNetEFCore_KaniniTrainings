using System.ComponentModel.DataAnnotations;

namespace MVC_CodeFirst.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; } 
        public string? categoryName { get; set; }
        public int price { get; set; }

    }
}
