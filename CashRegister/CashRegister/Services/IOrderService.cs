using CashRegister.Models;

namespace CashRegister.Services
{
    public interface IOrderService
    {

        Task<List<Order>> GetAsync();
        Task<Order?> GetAsync(string id);
        Task CreateAsync(Order newOrder);
        Task UpdateAsync(string id, Order updatedOrder);
        Task RemoveAsync(string id);
        Task<List<Order?>> GetOrdersOfToday();
            
    }
}
