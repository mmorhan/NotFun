using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints.Create;


public class CreateOrderItemEndpoint : IEndpoint<IResult, CreateOrderRequest, IRepository<Order>>
{
    private readonly IMapper _mapper;
    public CreateOrderItemEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }
    public void AddRoute(IEndpointRouteBuilder app)
    {
        // [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        app.MapPost("api/orders",
             async
            (CreateOrderRequest request, IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(request, orderRepository);
            })
            .Produces<CreateOrderResponse>()
            .WithTags("OrderEndpoints");
    }
    public async Task<IResult> HandleAsync(CreateOrderRequest request, IRepository<Order> orderRepository)
    {
        var response = new CreateOrderResponse(request.CorrelationId());

        // var domainOrder = _mapper.Map<Order>(request);
        var domainShipment = new Address(
            request.ShipToAddress.Street,
            request.ShipToAddress.City,
            request.ShipToAddress.State,
            request.ShipToAddress.Country,
            request.ShipToAddress.ZipCode);


        var orderList = new List<OrderItem>();
        foreach (var item in request.OrderItems)
        {
            var order=new OrderItem();


        }

        var order = new Order(request.BuyerId, shipToAddress, request);

        var existingOrder = await orderRepository.AddAsync(domainOrder);

        if (existingOrder.Id != 0)
        {
            return Results.Created($"api/orders/{existingOrder.Id}", response);
        }
        var dto = new OrderDto
        {
            Id = existingOrder.Id,
            BuyerId = existingOrder.BuyerId,
            ShipToAddress = _mapper.Map<AddressDto>(existingOrder.ShipToAddress),
            OrderItems = _mapper.Map<List<OrderItemDto>>(existingOrder.OrderItems),
        };
        response.Order = dto;
        return Results.Created($"api/orders/{dto.Id}", response);
    }
}