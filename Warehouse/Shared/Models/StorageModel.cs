using System;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace Warehouse.Shared.Models
{
    [FirestoreData]
    public class StorageModel
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

        [FirestoreDocumentCreateTimestamp]
        public DateTime CreateTime { get; set; }
        
        [FirestoreDocumentUpdateTimestamp]
        public DateTime UpdateTime { get; set; }
    }
}