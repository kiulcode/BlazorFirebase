using System.ComponentModel.DataAnnotations;

namespace Warehouse.Client.ViewModel
{
    public class InputTypeViewModel
    {
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        [StringLength(30, ErrorMessage = "⚠️ El nombre no debe exceder los 30 caracteres")]
        public string Name { get; set; }
    }
}