using System;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace Warehouse.Shared.Models
{
    [FirestoreData]
    public class WarehouseModel
    {
        [FirestoreDocumentId]
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        
        [FirestoreProperty] 
        public string ProductId { get; set; }
        
        [FirestoreProperty] 
        public int StockIncoming { get; set; }
        
        [FirestoreProperty] 
        public int StockOutgoing { get; set; }
        
        [FirestoreProperty] 
        public int StockExisting { get; set; }
        
        [FirestoreProperty] 
        public string Create { get; set; }
        
        [FirestoreDocumentCreateTimestamp]
        public DateTime CreateTime { get; set; }
    }
}