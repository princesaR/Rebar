using CashRegister.Models;

namespace CashRegister.Services
{
    public interface IAccuntService

    {
        Task<List<Accunt>> GetAsync();
        Task<Accunt?> GetAsync(string id);
        Task CreateAsync(Accunt newAccunt);
        Task UpdateAsync(string id, Accunt updatedAccunt);
        Task RemoveAsync(string id);

    }
}
