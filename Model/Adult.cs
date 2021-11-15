using System.ComponentModel.DataAnnotations;


namespace Models {
public class Adult : Person {
    
    public Job JobTitle { get; set; }
    
    [Range(18, int.MaxValue, ErrorMessage = "Have to be at least 18 years old to be adult")]
    public int Age { get; set; }
    
    public string Sex { get; set; }

    
}
}