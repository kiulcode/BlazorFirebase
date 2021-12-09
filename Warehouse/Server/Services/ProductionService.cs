using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class ProductionService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "Productions";

        public ProductionService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }
        
        public async Task<ProductionModel> CreateProduction(ProductionModel production)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var documentReference = await collection.AddAsync(production);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<ProductionModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task UpdateProduction(ProductionModel production)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection(CollectionName)
                    .Document(production.Id);
                await documentReference.SetAsync(production);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteProduction(string id)
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
        
        public async Task<IReadOnlyList<ProductionModel>> GetAllProductions()
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var allProductions = await collection.GetSnapshotAsync();

                return allProductions.Documents.Select(
                    document => document.ConvertTo<ProductionModel>()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<ProductionModel> GetProductionById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var production = await collection.Document(id).GetSnapshotAsync();

                return production.ConvertTo<ProductionModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}