using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services;
public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(HttpService httpService, ILogger<OrderService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<Order> Create(CreateOrderRequest order)
    {
        var response = await _httpService.HttpPost<CreateOrderResponse>("orders", order);
        return response?.Order;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching orders from API.");

        var orderListTask = _httpService.HttpGet<PagedOrderResponse>($"orders");
        await Task.WhenAll(orderListTask);
        var orders = orderListTask.Result.Orders;
        return orders;
    }
}