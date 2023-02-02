using AutoMapper;
using MediatR;
using webapi.CQRS.CommandCartItem;
using webapi.CQRS.CommandOrder;
using webapi.CQRS.CommandUser;
using webapi.Domain.Contracts;
using webapi.Domain.Models; //should be model and not entity
using webapi.Infrastructure.Database.Repository;

namespace webapi.CQRS.CommandHandlers
{
    //Multiple User Command Handler
    public class OrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteOrder(request.OrderId);
            return new Unit();
        }
    }
}
