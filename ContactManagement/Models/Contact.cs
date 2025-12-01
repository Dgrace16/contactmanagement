using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models;

public class Contact
{
    public int Id {get; set;}
    
    [Required]
    [MinLength(6, ErrorMessage = "The name must contain at least 6 letters.")]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "The contact number must have exactly 9 digits.")]
    public string ContactNumber { get; set; } =  string.Empty;
    
    [EmailAddress] public string Email { get; set; } =  string.Empty;
    
    public bool IsActive {get; set;} = true;
}