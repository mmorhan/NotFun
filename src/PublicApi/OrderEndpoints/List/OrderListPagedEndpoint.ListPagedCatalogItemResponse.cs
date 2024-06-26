﻿using System;
using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class ListPagedOrderResponse : BaseResponse
{
    public ListPagedOrderResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListPagedOrderResponse()
    {
    }
    public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    public int PageCount { get; set; }
}
