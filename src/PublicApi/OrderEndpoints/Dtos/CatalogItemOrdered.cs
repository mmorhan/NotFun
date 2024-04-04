
namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class CatalogItemOrderedDto
{

    public int Id { get; protected set; }
    public int CatalogItemId { get; private set; }
    public string ProductName { get; private set; }
    public string PictureUri { get; private set; }
}
