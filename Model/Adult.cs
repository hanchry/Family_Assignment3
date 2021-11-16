using System.ComponentModel.DataAnnotations;


namespace Model
{
    public class Adult:Person
    {
        
        public Job JobTittle { get; set; }
    }
}