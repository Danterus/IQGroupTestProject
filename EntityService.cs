using Microsoft.AspNetCore.Components;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp1
{
    public class EntityService
    {
        private readonly IMongoCollection<MyEntity> _collection;

        public EntityService(string connectionsString, string databaseName)
        {
            var mongoService = new MongoDBService(connectionsString, databaseName);
            _collection = mongoService.GetCollection<MyEntity>("myEntities");
        }

        public async Task InsertEntityAsync(MyEntity entity)
        {
            try
            {
                await _collection.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting entity: {ex.Message}");
            }

        }

        public bool HasKey(string email)
        {
            return true;
            //var query = Query.EQ("Email")
            //return _collection.
        }

        public async Task UpdateEntityAsync(string id, MyEntity entity)
        {
            try
            {
                await _collection.ReplaceOneAsync(x => x.Id == id, entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting entity: {ex.Message}");
            }
        }
    }
}
