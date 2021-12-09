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
        public string RawMaterialId { get; set; }
        
        [FirestoreProperty] 
        public string SectorId { get; set; }
        
        [FirestoreProperty] 
        public string PreserveTypeId { get; set; }
        
        [FirestoreProperty] 
        public string State { get; set; } = "En proceso";

        [FirestoreProperty] 
        public int EstimatedProduct { get; set; }
        
        [FirestoreProperty] 
        public string CreationDate { get; set; }
    }
}