﻿using CashRegister.Dto;
using CashRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.LogicLayer
{
    public interface IOrderLogic
    {
        Task<ActionResult<List<Order>>> Get();
        Task<Order> Post(OrderDto orderDto);
        Task<Order?> GetAsync(string id);

    }
}
