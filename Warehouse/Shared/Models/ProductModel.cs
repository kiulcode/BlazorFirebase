using System;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace Warehouse.Shared.Models
{
    [FirestoreData]
    public class ProductModel
    {
        [FirestoreDocumentId]
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        
        [FirestoreProperty] 
        public string ProductionId { get; set; }
        
        [FirestoreProperty] 
        public string Name { get; set; }
        
        [FirestoreProperty] 
        public double Weight { get; set; }
        
        [FirestoreProperty] 
        public int Stock { get; set; }
        
        [FirestoreProperty] 
        public string DateExpiration { get; set; }
        
        [FirestoreProperty] 
        public string DateProduction { get; set; }
        
        [FirestoreDocumentCreateTimestamp]
        public DateTime CreateTime { get; set; }
    }
}