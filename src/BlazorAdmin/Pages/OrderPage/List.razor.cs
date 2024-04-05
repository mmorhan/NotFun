using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Pages.OrderPage;

public partial class List : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderService OrderItemService { get; set; }

    private List<Order> Orders = new List<Order>();


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Orders = await OrderItemService.List();

            CallRequestRefresh();
        }

        await base.OnAfterRenderAsync(firstRender);
    }
}
