using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required, MinLength(1, ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required, MinLength(1, ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        public string HairColor { get; set; }
        public string EyeColor { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Age cannot be 0")]
        public int Age { get; set; }

        public float Weight { get; set; }
        public int Height { get; set; }
        [Required] public string Sex { get; set; }
    }
}