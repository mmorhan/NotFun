﻿
namespace BlazorShared.Models;

/// <summary>
/// Represents a snapshot of the item that was ordered. If catalog item details change, details of
/// the item that was part of a completed order should not change.
/// </summary>
public class CatalogItemOrdered // ValueObject
{
    public int Id { get; protected set; }
    public int CatalogItemId { get; private set; }
    public string ProductName { get; private set; }
    public string PictureUri { get; private set; }
}
