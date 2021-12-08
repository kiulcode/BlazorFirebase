using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Warehouse.Shared.Models;

namespace Warehouse.Server.Services
{
    public class InputTypeService
    {
        private readonly FirestoreDb _firestoreDb;

        public InputTypeService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\FirestoreApiKey\adminsdk-d709d-63d215d12a.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            _firestoreDb = FirestoreDb.Create("anchobetaswarehouse");
        }

        public async Task<InputTypeModel> CreateInputType(InputTypeModel inputType)
        {
            try
            {
                var collection = _firestoreDb.Collection("InputsTypes");
                var documentReference = await collection.AddAsync(inputType);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<InputTypeModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task UpdateInputType(InputTypeModel inputType)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection("InputsTypes")
                    .Document(inputType.Id);
                await documentReference.SetAsync(inputType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteInputType(string id)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection("InputsTypes")
                    .Document(id);
                await documentReference.DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<IReadOnlyList<InputTypeModel>> GetAllInputsTypes()
        {
            try
            {
                var collection = _firestoreDb.Collection("InputsTypes");
                var allInputTypeModel = await collection.GetSnapshotAsync();

                return allInputTypeModel.Documents.Select(
                    document => document.ConvertTo<InputTypeModel>()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<InputTypeModel> GetInputTypeById(string id)
        {
            try
            {
                var collection = _firestoreDb.Collection("InputsTypes");
                var inputTypeModel = await collection.Document(id).GetSnapshotAsync();

                return inputTypeModel.ConvertTo<InputTypeModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}