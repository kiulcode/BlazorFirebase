using System;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace Warehouse.Shared.Models
{
    [FirestoreData]
    public class ProductionModel
    {
        [FirestoreDocumentId]
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        
        [FirestoreProperty] 
        public string Name { get; set; }
        
        [FirestoreProperty] 
        public string SectorId { get; set; }
        
        [FirestoreProperty] 
        public string PreserveTypeId { get; set; }

        [FirestoreProperty] 
        public string State { get; set; }

        [FirestoreProperty] 
        public int EstimatedProduct { get; set; }

        [FirestoreProperty]
        public string Create { get; set; }

        [FirestoreDocumentCreateTimestamp]
        public DateTime CreateTime { get; set; }
    }
}