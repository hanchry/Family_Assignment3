using System.ComponentModel.DataAnnotations;
namespace Model
{
    public class User
    {   [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
       // public string Email { get; set; }
        // public int SecurityLevel { get; set; }
    }
}