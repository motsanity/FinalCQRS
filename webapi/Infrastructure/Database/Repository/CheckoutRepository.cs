using AutoMapper;
using webapi.Domain.Models;
using webapi.Infrastructure.Database.Contexts;
using webapi.Domain.Contracts;
using webapi.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace webapi.Infrastructure.Database.Repository
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CheckoutRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Guid> CheckoutOrder(CheckoutModel checkout)
        {
            
            var entity = _mapper.Map<Entities.Checkout>(checkout);
            var order = _context.Orders.FirstOrDefault(r => r.OrderId == checkout.OrderPrimaryId);

            var checkoutorder = new Checkout()
            {
                OrderPrimaryId = checkout.OrderPrimaryId,
                CustomerId = order.CustomerId,
                Status = (short)checkout.Status,
            }; _context.Checkouts.Add(checkoutorder);
            


            order.Status = (short)checkout.Status;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return entity.CheckoutId;

            
        }
    }
            
}
