using MongoDB.Driver;
using CashRegister.Models;
using CashRegister.Data;

namespace CashRegister.Services
{
    public class ShakeService : IShakeService
    {

        private readonly IMongoCollection<Shake> _shakes;

        public ShakeService(MongodbRebarContext context)
        {
            _shakes = context.Shakes();
        }


        public async Task<List<Shake>> GetAsync() =>
        await _shakes.Find(_ => true).ToListAsync();

        public async Task<Shake?> GetAsync(string id) =>
        await _shakes.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Shake newShake) =>
            await _shakes.InsertOneAsync(newShake);

        public async Task UpdateAsync(string id, Shake updatedShake) =>
            await _shakes.ReplaceOneAsync(x => x.Id == id, updatedShake);

        public async Task RemoveAsync(string id) =>
            await _shakes.DeleteOneAsync(x => x.Id == id);

        public string GetIdByNameAsync(string name)
        {
            var shake = _shakes.Find(x => x.Name.Equals(name)).First();
            if (shake == null)
            {
                throw new ArgumentNullException(nameof(name), "shake not found");
            }
            return shake.Id;
        }

       
    }
}
