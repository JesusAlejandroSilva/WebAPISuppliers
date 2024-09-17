using Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Persistence
{
    public class DbContextApp
    {
        private readonly IMongoDatabase _database;

        public DbContextApp(IConfiguration configuration)
        {
 
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase(configuration["GestionProveedores"]);
        }

  
        public IMongoCollection<Suppliers> Proveedores => _database.GetCollection<Suppliers>("Proveedores");
    }
}

