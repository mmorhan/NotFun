namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class AddressDto // ValueObject
{

    public int Id { get; protected set; }
    public string Street { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public string Country { get; private set; }

    public string ZipCode { get; private set; }
}
