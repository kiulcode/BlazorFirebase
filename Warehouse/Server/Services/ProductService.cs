using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class ProductService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string CollectionName = "Products";

        public ProductService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }
        
        public async Task<ProductModel> CreateProduct([FromBody] ProductModel product)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var documentReference = await collection.AddAsync(product);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<ProductModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task UpdateProduct([FromBody] ProductModel product)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection(CollectionName)
                    .Document(product.Id);
                await documentReference.SetAsync(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteProduct(string id)
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
        
        public async Task<IReadOnlyList<ProductModel>> GetAllProducts()
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var allProducts = await collection.GetSnapshotAsync();

                return allProducts.Documents.Select(
                    document => document.ConvertTo<ProductModel>())
                    .OrderByDescending(product => product.CreateTime)
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<ProductModel> GetProductById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var product = await collection.Document(id).GetSnapshotAsync();

                return product.ConvertTo<ProductModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}