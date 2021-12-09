﻿using System;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace Warehouse.Client.ViewModel
{
    public class ProductionViewModel
    {
        public string ID { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string RawMaterialId { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string SectorId { get; set; }
        
        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public string PreserveTypeId { get; set; }
        
        public string State { get; set; } = "En proceso";

        [Required(ErrorMessage = "⚠️ Campo requerido")]
        public int EstimatedProduct { get; set; }
        
        public string Create { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.Today;
    }
}