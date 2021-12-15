using System;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Client.ViewModel
{
    public class ProductViewModel
    {
        public string ID { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string ProductionId { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public double Weight { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public int Stock { get; set; }
        
        public string DateExpiration { get; set; }
        
        public string DateProduction { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public DateTime? Date1 { get; set; } = DateTime.Today;
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public DateTime? Date2 { get; set; } = DateTime.Today;
    }
}