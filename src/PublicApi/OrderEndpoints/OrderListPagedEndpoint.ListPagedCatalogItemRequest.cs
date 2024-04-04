namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;

public class ListPagedOrderRequest : BaseRequest
{
    public int PageSize { get; init; }
    public int PageIndex { get; init; }
    public string buyerId { get; set; }
}
