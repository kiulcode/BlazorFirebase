using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class StorageService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "Warehouse";

        public StorageService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }
        
        public async Task<StorageModel> CreateStorage(StorageModel warehouse)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var documentReference = await collection.AddAsync(warehouse);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<StorageModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task UpdateStorage(StorageModel warehouse)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection(CollectionName)
                    .Document(warehouse.Id);
                await documentReference.SetAsync(warehouse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteStorage(string id)
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
        
        public async Task<IReadOnlyList<StorageModel>> GetAllStorages()
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var allWarehouse = await collection.GetSnapshotAsync();

                return allWarehouse.Documents.Select(
                    document => document.ConvertTo<StorageModel>())
                    .OrderByDescending(warehouse => warehouse.CreateTime)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<StorageModel> GetStorageById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var warehouse = await collection.Document(id).GetSnapshotAsync();

                return warehouse.ConvertTo<StorageModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}