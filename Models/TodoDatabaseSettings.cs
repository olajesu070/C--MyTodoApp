namespace MyTodoApp.Models
{
    public class TodoDatabaseSettings : ITodoDatabaseSettings
    {
        public string? ConnectionString { get; set; }  // Nullable
        public string? DatabaseName { get; set; }      // Nullable
        public string? TodoCollectionName { get; set; } // Nullable
    }

    public interface ITodoDatabaseSettings
    {
        string? ConnectionString { get; set; }  // Nullable
        string? DatabaseName { get; set; }      // Nullable
        string? TodoCollectionName { get; set; } // Nullable
    }
}
