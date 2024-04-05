using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{

    [Required]
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public AddressDto ShipToAddress { get; set; }
    public List<OrderItemDto> OrderItems = new List<OrderItemDto>();

}
