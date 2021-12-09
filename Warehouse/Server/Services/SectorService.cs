using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class SectorService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "Sectors";

        public SectorService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }
        
        public async Task<IReadOnlyList<SectorModel>> GetAllSectors()
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var allSectors = await collection.GetSnapshotAsync();

                return allSectors.Documents.Select(
                    document => document.ConvertTo<SectorModel>()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<SectorModel> GetSectorById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var sector = await collection.Document(id).GetSnapshotAsync();

                return sector.ConvertTo<SectorModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}