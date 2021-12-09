using System;
using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace Warehouse.Shared.Models
{
    [FirestoreData]
    public class RawMaterialModel
    {
        [FirestoreDocumentId]
        [JsonPropertyName("ID")]
        public string Id { get; set; }

        [FirestoreProperty]
        public string InputId { get; set; }

        [FirestoreProperty]
        public int IncomingQuantity { get; set; }

        [FirestoreProperty]
        public int OutgoingQuantity { get; set; }

        [FirestoreProperty]
        public int Residuals { get; set; }

        [FirestoreProperty]
        public int Reusable { get; set; }

        [FirestoreProperty]
        public string Create { get; set; }
        
        [FirestoreDocumentCreateTimestamp]
        public DateTime CreateTime { get; set; }
    }
}