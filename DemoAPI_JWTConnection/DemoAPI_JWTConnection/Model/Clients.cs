using System.ComponentModel.DataAnnotations;

namespace DemoAPI_JWTConnection.Model
{
    public class Clients
    {
        [Key]
        public int clientId { get; set; }
        public string clientName { get; set; }
        public string clientEmail { get; set; }
        public string role { get; set; } = "Client"; 

    }
}
