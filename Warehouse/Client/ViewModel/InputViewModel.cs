using System.ComponentModel.DataAnnotations;

namespace Warehouse.Client.ViewModel
{
    public class InputViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string InputTypeId { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        [StringLength(30, ErrorMessage = "⚠️ El nombre no debe exceder los 30 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string UnitMeasure { get; set; }
    }
}