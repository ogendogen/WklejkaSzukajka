using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Models;
using MongoDB.Driver;

namespace Database
{
    public class MongoDb : IDatabase
    {
        public MongoClient MongoClient { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }
        public IMongoCollection<DocEntry> DocsCollection { get; set; }

        public MongoDb(string connectionString)
        {
            MongoClient = new MongoClient(connectionString);

            MongoDatabase = MongoClient.GetDatabase("wklejto");
            DocsCollection = MongoDatabase.GetCollection<DocEntry>("docs");
        }

        public async Task<IEnumerable<int>> GetDocsIdsByContains(string condition)
        {
            List<int> ids = new List<int>();
            
            FindOptions<DocEntry> options = new FindOptions<DocEntry>
            {
                BatchSize = 5,
                NoCursorTimeout = false
            };

            using (var cursor = await DocsCollection.FindAsync(doc => doc.Content.Contains(condition), options))
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (DocEntry doc in cursor.Current)
                    {
                        ids.Add(doc.PageID);
                    }
                }
            }

            return ids;
        }
    }
}
