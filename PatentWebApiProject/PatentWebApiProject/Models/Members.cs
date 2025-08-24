using System.ComponentModel.DataAnnotations;

namespace PatentWebApiProject.Models
{
    public class Members
    {
        [Key]
        public int memId { get; set; }
        public string name { get; set; } 
        public string? email { get; set; } = default!;
        public string? role { get; set; } = "user";
        public string? city { get; set; } = "Chennai";
        public DateTime createdAt { get; set; } = DateTime.Now;
        public ICollection<Patent>? patents { get; set; } = new List<Patent>();
    }
}
