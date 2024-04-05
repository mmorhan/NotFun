﻿using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{

    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public AddressDto ShipToAddress { get; set; }
    public List<OrderItemDto> OrderItems = new List<OrderItemDto>();

}
