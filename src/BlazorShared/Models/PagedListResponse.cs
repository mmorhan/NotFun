using System.Collections.Generic;

namespace BlazorShared.Models;

public class PagedListResponse<T> where T : class
{
    public List<T> Items { get; set; } = new List<T>();
    public int PageCount { get; set; } = 0;
}
