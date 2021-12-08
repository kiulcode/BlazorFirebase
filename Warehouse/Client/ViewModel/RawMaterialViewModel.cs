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

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public int Waste { get; set; }

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public int Reusable { get; set; }

        public string CreateTime { get; set; }
        
        public DateTime? CreateTimeDate { get; set; } = DateTime.Today;
    }
}