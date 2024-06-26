﻿using System;
using System.Collections.Generic;

namespace BlazorShared.Models;

public class Order
{

    public int Id { get; protected set; }
    public string BuyerId { get; private set; }
    public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
    public Address ShipToAddress { get; private set; }
    public List<OrderItem> OrderItems = new List<OrderItem>();

}
