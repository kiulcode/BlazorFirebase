using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class ProductionMaterialService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "ProductionMaterials";

        public ProductionMaterialService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }

        public async Task<ProductionMaterialModel> CreateProductionMaterial(ProductionMaterialModel productionMaterial)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var documentReference = await collection.AddAsync(productionMaterial);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<ProductionMaterialModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdateProductionMaterial(ProductionMaterialModel productionMaterial)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection(CollectionName)
                    .Document(productionMaterial.Id);
                await documentReference.SetAsync(productionMaterial);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteProductionMaterial(string id)
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

        public async Task<IReadOnlyList<ProductionMaterialModel>> GetAllProductionMaterials()
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var allProductions = await collection.GetSnapshotAsync();

                return allProductions.Documents.Select(
                        document => document.ConvertTo<ProductionMaterialModel>())
                    .OrderByDescending(production => production.CreateTime)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ProductionMaterialModel> GetProductionMaterialById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var production = await collection.Document(id).GetSnapshotAsync();

                return production.ConvertTo<ProductionMaterialModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}