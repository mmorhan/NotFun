
using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class CatalogItemOrderedDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int CatalogItemId { get; set; }

    [Required]
    public string ProductName { get; set; }
    public string PictureUri { get; set; }
}
