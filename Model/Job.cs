using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Job
    {
        [Key] 
        public int Id { get; set; }
        public string JobTitle { get; set; }

        public int Salary { get; set; }
    }
}