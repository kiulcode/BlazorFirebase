using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class InputService
    {
        private readonly FirestoreDb _firestoreDb;

        public InputService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }
        
        public async Task<InputModel> CreateInput(InputModel input)
        {
            try
            {
                var collection = _firestoreDb.Collection("Inputs");
                var documentReference = await collection.AddAsync(input);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<InputModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task UpdateInput(InputModel input)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection("Inputs")
                    .Document(input.Id);
                await documentReference.SetAsync(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteInput(string id)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection("Inputs")
                    .Document(id);
                await documentReference.DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<IReadOnlyList<InputModel>> GetAllInputs()
        {
            try
            {
                var collection = _firestoreDb.Collection("Inputs");
                var allInputModel = await collection.GetSnapshotAsync();

                return allInputModel.Documents.Select(
                    document => document.ConvertTo<InputModel>()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<InputModel> GetInputById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection("Inputs");
                var inputModel = await collection.Document(id).GetSnapshotAsync();

                return inputModel.ConvertTo<InputModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}