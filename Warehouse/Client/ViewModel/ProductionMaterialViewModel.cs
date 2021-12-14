using System.ComponentModel.DataAnnotations;

namespace Warehouse.Client.ViewModel
{
    public class ProductionMaterialViewModel
    {
        public string ID { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string ProductionId { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string RawMaterialId { get; set; }
    }
}