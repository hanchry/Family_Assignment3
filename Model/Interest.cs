using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Model
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description{ get; set; }
        


    }
}