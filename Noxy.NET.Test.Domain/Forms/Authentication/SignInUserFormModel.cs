using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Noxy.NET.Test.Domain.Forms.Authentication;

public class SignInUserFormModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(12), MaxLength(512)]
    [DisplayName("Password")]
    public string Password { get; set; } = string.Empty;
}
