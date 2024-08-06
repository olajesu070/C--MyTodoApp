using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyTodoApp.Models
{
    public class Todo
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("text")] // Ensure the field name matches MongoDB
        public string Text { get; set; } = string.Empty;

        [BsonElement("completed")] // Ensure the field name matches MongoDB
        public bool Completed { get; set; }

        // Parameterless constructor
        public Todo() { }
    }
}
