using System.ComponentModel.DataAnnotations;

namespace Warehouse.Client.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        [EmailAddress(ErrorMessage = "⚠️ Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string Password { get; set; }
    }
}