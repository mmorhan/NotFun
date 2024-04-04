
using System;
using System.Collections.Generic;

namespace BlazorShared.Models;
public class CreaetOrderRequest
{
    public int Id { get; protected set; }
    public string BuyerId { get; private set; }
    public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
    public List<OrderItem> _orderItems = new List<OrderItem>();

}