using CashRegister.Models;
using MongoDB.Driver;

namespace CashRegister.Data
{
    public class MongodbRebarContext
    {
        private readonly IMongoDatabase _database;

        public MongodbRebarContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Shake> Shakes()
        {
           return _database.GetCollection<Shake>("Shakes");
        } 

        public IMongoCollection<Order> Orders()
        {
           return _database.GetCollection<Order>("Orders");
        }

        public IMongoCollection<Accunt> Accunts()
        {
            return _database.GetCollection<Accunt>("Accunts");
        }
    }
}
