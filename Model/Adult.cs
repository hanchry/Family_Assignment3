using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models {
public class Adult : Person {
    
    
    
    
    [Range(18, int.MaxValue, ErrorMessage = "Have to be at least 18 years old to be adult")]
    public int Age { get; set; }
    
    public string Sex { get; set; }
    
    public Job JobTitle { get; set; }
    
}
}