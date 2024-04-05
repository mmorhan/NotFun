using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints.Create;

public class CreateOrderResponse : BaseResponse
{
    public CreateOrderResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateOrderResponse()
    {
    }

    public OrderDto Order { get; set; }
}
