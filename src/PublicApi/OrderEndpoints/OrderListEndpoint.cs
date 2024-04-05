using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderListEndpoint : IEndpoint<IResult, ListPagedOrderRequest, IRepository<Order>>
{
    private readonly IMapper _mapper;

    public OrderListEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order-items",
            async (int? pageSize, int? pageIndex, string? buyerId, IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(new ListPagedOrderRequest(pageSize, pageIndex, buyerId), itemRepository);
            })
            .Produces<ListPagedOrderResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(ListPagedOrderRequest request, IRepository<Order> itemRepository)
    {
        var response = new ListPagedOrderResponse();

        int totalItems = await itemRepository.CountAsync();

        var pagedSpec = new CustomerOrdersSpecification(
            buyerId: request.BuyerId);

        var items = new List<OrderDto>()
        {
            new OrderDto(){
                BuyerId="1",
                OrderDate=DateTimeOffset.Now,
                ShipToAddress=new AddressDto(){
                    Id=1,
                    City="Redmond",
                },
                OrderItems = new List<OrderItemDto>(){
                    new OrderItemDto(){
                        Id=1,
                        UnitPrice=10,
                        Units=1,
                        ItemOrdered=new CatalogItemOrderedDto(){
                            Id=1,
                            CatalogItemId=1,
                            ProductName="Product 1",
                            PictureUri="https://picsum.photos/200/300",
                        }
                    }
                }
            },
            new OrderDto(){
                BuyerId="1",
                OrderDate=DateTimeOffset.Now,
                ShipToAddress=new AddressDto(){
                    Id=1,
                    City="Redmond",
                },
                OrderItems = new List<OrderItemDto>(){
                    new OrderItemDto(){
                        Id=1,
                        UnitPrice=10,
                        Units=1,
                        ItemOrdered=new CatalogItemOrderedDto(){
                            Id=1,
                            CatalogItemId=1,
                            ProductName="Product 1",
                            PictureUri="https://picsum.photos/200/300",
                        },
                    },
                }
            }
        };

        response.Orders.AddRange(items.Select(_mapper.Map<OrderDto>));

        if (request.PageSize > 0)
        {
            response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
        }
        else
        {
            response.PageCount = totalItems > 0 ? 1 : 0;
        }

        return Results.Ok(response);
    }
}