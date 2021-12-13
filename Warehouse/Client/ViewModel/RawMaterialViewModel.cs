using System;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace Warehouse.Client.ViewModel
{
    public class RawMaterialViewModel
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string InputId { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public int IncomingQuantity { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public int OutgoingQuantity { get; set; }

        public string Create { get; set; }
        
        public DateTime? CreateDate { get; set; } = DateTime.Today;
    }
}