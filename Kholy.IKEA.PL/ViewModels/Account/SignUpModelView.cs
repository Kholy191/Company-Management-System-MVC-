using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace Kholy.IKEA.PL.ViewModels.Account
{
    public class SignUpModelView
    {
        [Display(Name = "FirstName")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "LastName")]
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password, ErrorMessage = "Weak Password")]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;

        [RequiredTrue(ErrorMessage = "You must agree to the terms and conditions.")]
        public bool IsAgreed { get; set; }

        public class RequiredTrueAttribute : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                return value is bool boolValue && boolValue;
            }
        }
    }
}
