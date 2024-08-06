using MongoDB.Bson;
using MongoDB.Driver;
using MyTodoApp.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTodoApp.Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todos;

        public TodoService(IConfiguration config)
        {
            var mongoClient = new MongoClient(config["TodoDatabaseSettings:ConnectionString"]);
            var mongoDatabase = mongoClient.GetDatabase(config["TodoDatabaseSettings:DatabaseName"]);
            _todos = mongoDatabase.GetCollection<Todo>(config["TodoDatabaseSettings:TodoCollectionName"]);
        }

        public async Task<List<Todo>> GetAsync() =>
            await _todos.Find(todo => true).ToListAsync();

        public async Task<Todo> GetAsync(string id)
        {
            var objectId = ObjectId.Parse(id); // Convert string to ObjectId
            return await _todos.Find<Todo>(todo => todo.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Todo todo) =>
            await _todos.InsertOneAsync(todo);

        public async Task UpdateAsync(string id, Todo todoIn)
        {
            var objectId = ObjectId.Parse(id); // Convert string to ObjectId
            await _todos.ReplaceOneAsync(todo => todo.Id == objectId, todoIn);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = ObjectId.Parse(id); // Convert string to ObjectId
            await _todos.DeleteOneAsync(todo => todo.Id == objectId);
        }
    }
}
