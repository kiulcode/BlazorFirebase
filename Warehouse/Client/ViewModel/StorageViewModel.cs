using System.ComponentModel.DataAnnotations;

namespace Warehouse.Client.ViewModel
{
    public class StorageViewModel
    {
        public string ID { get; set; }
         
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string ProductId { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public int StockIncoming { get; set; }
        
        public int StockOutgoing { get; set; }
    }
}