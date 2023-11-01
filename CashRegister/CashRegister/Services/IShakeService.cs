using CashRegister.Models;

namespace CashRegister.Services
{
    public interface IShakeService
    {
        
        Task<List<Shake>> GetAsync();
        Task<Shake?> GetAsync(string id);
        Task CreateAsync(Shake newShake);
        Task UpdateAsync(string id, Shake updatedShake);
        Task RemoveAsync(string id);

        string GetIdByNameAsync(string name);
        
    }
}
