using FIXXOUPPGIFT.ViewModels;

namespace FIXXOUPPGIFT.Models.Dtos
{
    public class LoginModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;


        public static implicit operator LoginViewModel(LoginModel model)
        {
            return new LoginViewModel
            {
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}
