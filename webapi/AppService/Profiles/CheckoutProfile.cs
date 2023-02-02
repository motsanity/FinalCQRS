using AutoMapper;
using webapi.AppService.DTOCartItem;
using webapi.AppService.DTOCheckout;
using webapi.CQRS.CommandCartItem;
using webapi.CQRS.CommandCheckout;
using webapi.CQRS.ViewModels;
using webapi.Domain.Models;
using webapi.Infrastructure.Database.Entities;


namespace webapi.AppService.Profiles
{
    public class CheckoutProfile : Profile //added 5:21pm 1/24/2023
    {
        public CheckoutProfile()
        {
            CreateMap<webapi.Domain.Models.CheckoutModel, webapi.Infrastructure.Database.Entities.Checkout>();
            CreateMap<CheckoutOrderDTO, CheckoutOrderCommand>();
            CreateMap<CheckoutOrderCommand, CheckoutModel>();
            //.ConstructUsing((s) => new CartItemModel(s.CartItemName, s.CustomerId, s.OrderId));

            CreateMap<CheckoutModel, CheckoutViewModel>();
            CreateMap<UpdateCartItemDTO, UpdateCartItemCommand>();

            CreateMap<CheckoutModel, Infrastructure.Database.Entities.Checkout>()
                .ForMember(d => d.Status, o => o.MapFrom(s => (short)s.Status));
            CreateMap<Infrastructure.Database.Entities.Checkout, CheckoutModel>();





        }



    }
}
