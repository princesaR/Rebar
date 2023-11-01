﻿using CashRegister.Data;
using CashRegister.Models;
using MongoDB.Driver;

namespace CashRegister.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(MongodbRebarContext context)
        {
            _orders = context.Orders();
        }
       

        public async Task<List<Order>> GetAsync()
        {
           return await _orders.Find(x => true).ToListAsync();
           
        }

        public async Task<Order?> GetAsync(string id)
        {
         return await _orders.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Order newOrder)
        {
            await _orders.InsertOneAsync(newOrder);
        }

        public async Task UpdateAsync(string id, Order updatedOrder)
        {
            await _orders.ReplaceOneAsync(x => x.Id == id, updatedOrder);
        }
        public async Task RemoveAsync(string id)
        {
            await _orders.DeleteOneAsync(x => x.Id == id);
        }

        public Task<List<Order?>> GetOrdersOfToday()
        {
            throw new NotImplementedException();
        }
    }
}
