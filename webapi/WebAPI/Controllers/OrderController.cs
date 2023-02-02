using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.AppService.DTOCartItem;
using webapi.AppService.DTOUser;
using webapi.CQRS.CommandCartItem;
using webapi.CQRS.CommandOrder;
using webapi.CQRS.CommandUser;
using webapi.CQRS.QueryItem;
using webapi.CQRS.QueryOrder;
using webapi.CQRS.QueryUser;
using webapi.CQRS.ViewModels;
using webapi.Infrastructure.Database.Entities;
using webapi.WebAPI.Common;
using UpdateCartItemDTO = webapi.AppService.DTOCartItem.UpdateCartItemDTO;

namespace webapi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {

        //added 5:02 1/24/2023
        public OrderController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }


        [HttpGet("/GetAllOrder")]
        public async Task<IActionResult> GetAllOrders()
        {
            return await Handle<IEnumerable<OrderViewModel>>(new GetAllOrdersQuery());
        }

   

        [HttpGet]
        [Route("/GetOrderById")]
        public async Task<IActionResult> GetUserById([FromQuery] GetOrderByIdQuery query)
        {
            return await Handle<OrderViewModel>(query);
        }

        [HttpGet]
        [Route("GetAllOrderByStatus")]
        public async Task<IActionResult> GetAllOrderByStatus([FromQuery] GetAllOrderByStatusQuery query)
        {
            return await Handle<IEnumerable<OrderViewModel>>(query);
        }





        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand dto)
        {
            //use UpdateCartItemDTO since they almost share the same method/properties
            return await Handle<UpdateCartItemDTO, DeleteOrderCommand, object>(dto);
        }
    }
}
