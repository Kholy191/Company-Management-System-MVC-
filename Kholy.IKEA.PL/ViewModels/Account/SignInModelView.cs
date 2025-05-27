using System.ComponentModel.DataAnnotations;

namespace Kholy.IKEA.PL.ViewModels.Account
{
    public class SignInModelView
    {
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; } = false;
    }
}
