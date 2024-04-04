﻿
namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderItemDto
{
    public int Id { get; set; }
    public CatalogItemOrderedDto ItemOrdered { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
}
