using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class PreserveTypeService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "PreservesTypes";

        public PreserveTypeService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }
        
        public async Task<IReadOnlyList<PreserveTypeModel>> GetAllPreservesTypes()
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var allPreservesTypes = await collection.GetSnapshotAsync();

                return allPreservesTypes.Documents.Select(
                    document => document.ConvertTo<PreserveTypeModel>()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<PreserveTypeModel> GetPreserveTypeById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var preserveType = await collection.Document(id).GetSnapshotAsync();

                return preserveType.ConvertTo<PreserveTypeModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}