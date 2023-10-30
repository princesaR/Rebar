using MongoDB.Driver;
using CashRegister.Models;
using Microsoft.Extensions.Options;

namespace CashRegister.Services
{
    public class ShakesServices
    {
        private readonly IMongoCollection<Shake> _shakesCollection;

        public ShakesServices(IOptions<ShakesOrdersDatabaseSettings> shakesOrdersDatabaseSettings)
        {
            var mongoClient = new MongoClient(
            shakesOrdersDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                shakesOrdersDatabaseSettings.Value.DatabaseName);

            _shakesCollection = mongoDatabase.GetCollection<Shake>(
                shakesOrdersDatabaseSettings.Value.ShakesCollectionName);
        }

        public async Task<List<Shake>> GetAsync() =>
        await _shakesCollection.Find(_ => true).ToListAsync();

        public async Task<Shake?> GetAsync(string name) =>
        await _shakesCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Shake newBook) =>
            await _shakesCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Shake updatedShake) =>
            await _shakesCollection.ReplaceOneAsync(x => x.Id == id, updatedShake);

        public async Task RemoveAsync(string id) =>
            await _shakesCollection.DeleteOneAsync(x => x.Id == id);

    }
}
