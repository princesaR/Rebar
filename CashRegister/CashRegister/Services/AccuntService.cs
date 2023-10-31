using CashRegister.Data;
using CashRegister.Models;
using MongoDB.Driver;

namespace CashRegister.Services
{
    public class AccuntService : IAccuntService
    {
        private readonly IMongoCollection<Accunt> _accunts;

        public AccuntService(MongodbRebarContext context)
        {

            var _accunts = context.Accunts();
        }
       
        public async Task<List<Accunt>> GetAsync()
        {
            return await _accunts.Find(_ => true).ToListAsync();
        }

        public async Task<Accunt?> GetAsync(string id)
        {
            return await _accunts.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Accunt newAccunt)
        {
            await _accunts.InsertOneAsync(newAccunt);
        }


        public async Task UpdateAsync(string id, Accunt updatedAccunt)
        {
            await _accunts.ReplaceOneAsync(x => x.Id == id, updatedAccunt);
        }

        public async Task RemoveAsync(string id)
        {
            await _accunts.DeleteOneAsync(x => x.Id == id);
        }
    }
}
