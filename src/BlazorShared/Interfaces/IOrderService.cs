using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;

public interface IOrderService
{
    Task<Order> Create(CreateOrderRequest catalogOrder);
    Task<List<Order>> List();
}
