using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Models
{
    public class Interest
    {
        [Key]
        public string Type { get; set; }
        public string Description{ get; set; }
        


    }
}