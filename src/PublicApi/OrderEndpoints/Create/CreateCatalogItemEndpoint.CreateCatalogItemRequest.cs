using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints.Create;

public class CreateOrderRequest : BaseRequest
{
    public string BuyerId { get; set; }
    public AddressDto ShipToAddress { get; set; }
    [Required]
    public List<OrderItemDto> OrderItems = new List<OrderItemDto>();
}
