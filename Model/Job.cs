using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Job
    {
        public Job()
        {
            JobTitle = "no tittle";
            Salary = 0;
        }
        
        public string JobTitle { get; set; }
      
        public int Salary { get; set; }
    }
}