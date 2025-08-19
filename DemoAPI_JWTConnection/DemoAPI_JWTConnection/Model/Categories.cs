using System.ComponentModel.DataAnnotations;

namespace DemoAPI_JWTConnection.Model
{
    public class Categories
    {
        [Key]
        public int catId { get; set; }
        public string catName { get; set; }
        public int price { get; set; }
    }
}
