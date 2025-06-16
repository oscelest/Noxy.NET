using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Attributes;

namespace Noxy.NET.Test.Domain.Forms.Authentication;

public class SignUpUserFormModel
{
    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(12), MaxLength(512)]
    [DisplayName("Password")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [PropertyMatchValidation(nameof(Password))]
    [DisplayName("Confirm password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
