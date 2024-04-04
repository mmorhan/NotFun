using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{

    public int Id { get; protected set; }
    public string BuyerId { get; private set; }
    public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
    public AddressDto ShipToAddress { get; private set; }
    public List<OrderItemDto> OrderItems = new List<OrderItemDto>();

}
