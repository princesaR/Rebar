using CashRegister.Dto;
using CashRegister.Models;
using CashRegister.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.LogicLayer

public class OrderLogic : IOrderLogic
{
    private readonly IOrderService _orderService;
    private readonly IShakeService _shakeService;
    public OrderLogic(IOrderService orderService, IShakeService shakeService)
    {
        _orderService = orderService;
        _shakeService = shakeService;
    }

    private Order CreateOrder(OrderDto orderDto)
    {
        var shakesId = CheckOredredShakes(orderDto.Shakes);
        var discounts = CheckDiscount(orderDto.Discounts);
        var totalPrice = orderDto.Shakes.Sum(x =>  x.Price);
        var order = new Order(shakesId, totalPrice, orderDto.Name, discounts);

        return order;
    }

    private List<string> CheckOredredShakes(List<OrderedShakeDto> shakesDto)
    {
        var shakesId = new List<string>();
        shakesDto.ForEach(x =>
        {
            var id = _shakeService.GetIdByNameAsync(x.Name).ToString();
            if (!string.IsNullOrEmpty(id))
            {
                shakesId.Add(id);
            }
        });

            return shakesId;
    }
    private List<Discount> CheckDiscount(List<DiscountDto> discoutnsDto)
    {
        var discounts = new List<Discount>();
        discoutnsDto.ForEach(d => discounts.Add(new Discount(d.Percentage, d.Discription)));
        return discounts;
    }

    public async Task<ActionResult<List<Order>>> Get()
    {
        return await _orderService.GetAsync();
    }

    public async Task<Order> Post(OrderDto orderDto)
    {
        var order = CreateOrder(orderDto);
        await _orderService.CreateAsync(order);

        return order;
    }

    public async Task<Order?> GetAsync(string id)
    {
        try
        {
            return await _orderService.GetAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
       
    }
}
