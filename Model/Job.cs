using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Job
    {
        public Job()
        {
            JobTitle = "no tittle";
            Salary = 0;
        }
        [Key]
        public string JobTitle { get; set; }
      
        public int Salary { get; set; }
    }
}