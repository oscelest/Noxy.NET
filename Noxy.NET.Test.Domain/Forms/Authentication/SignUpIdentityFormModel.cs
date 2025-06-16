using System.ComponentModel.DataAnnotations;

namespace Noxy.NET.Test.Domain.Forms.Authentication;

public class SignUpIdentityFormModel
{    
    [Required]
    [MinLength(3), MaxLength(32)]
    public string Handle { get; set; } = string.Empty;
    
    [Required]
    [MinLength(3), MaxLength(32)]
    public string Username { get; set; } = string.Empty;
}
