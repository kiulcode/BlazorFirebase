using System;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace Warehouse.Shared.Models
{
    [FirestoreData]
    public class ProductionMaterialModel
    {
        [FirestoreDocumentId]
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        
        [FirestoreProperty] 
        public string ProductionId { get; set; }
        
        [FirestoreProperty] 
        public string RawMaterialId { get; set; }
        
        [FirestoreDocumentCreateTimestamp]
        public DateTime CreateTime { get; set; }
    }
}