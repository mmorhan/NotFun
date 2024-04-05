﻿namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class AddressDto // ValueObject
{

    public int Id { get;  set; }
    public string Street { get;  set; }

    public string City { get;  set; }

    public string State { get;  set; }

    public string Country { get;  set; }

    public string ZipCode { get;  set; }
}
