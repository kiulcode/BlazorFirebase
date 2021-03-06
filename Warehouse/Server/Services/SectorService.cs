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
        
        public async Task<SectorModel> CreateSector([FromBody] SectorModel sector)
        {
            try
            {
                var collection = _firestoreDb.Collection(CollectionName);
                var documentReference = await collection.AddAsync(sector);
                var document = await documentReference.GetSnapshotAsync();

                return document.ConvertTo<SectorModel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task UpdateSector([FromBody] SectorModel sector)
        {
            try
            {
                var documentReference = _firestoreDb
                    .Collection(CollectionName)
                    .Document(sector.Id);
                await documentReference.SetAsync(sector);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task DeleteSector(string id)
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