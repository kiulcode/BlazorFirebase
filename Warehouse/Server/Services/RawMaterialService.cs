using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class RawMaterialService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "RawMaterials";

        public RawMaterialService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }
        
        public async Task<RawMaterialModel> CreateRawMaterial(RawMaterialModel rawMaterial)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var documentReference = await collection.AddAsync(rawMaterial);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<RawMaterialModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task UpdateRawMaterial(RawMaterialModel rawMaterial)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection(CollectionName)
                    .Document(rawMaterial.Id);
                await documentReference.SetAsync(rawMaterial);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteRawMaterial(string id)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection(CollectionName)
                    .Document(id);
                await documentReference.DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<IReadOnlyList<RawMaterialModel>> GetAllRawMaterials()
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var allRawMaterials = await collection.GetSnapshotAsync();

                return allRawMaterials.Documents.Select(
                    document => document.ConvertTo<RawMaterialModel>()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<RawMaterialModel> GetRawMaterialById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var rawMaterial = await collection.Document(id).GetSnapshotAsync();

                return rawMaterial.ConvertTo<RawMaterialModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}