using MediatR;
using webapi.CQRS.ViewModels;

namespace webapi.CQRS.QueryOrder
{
    public class GetOrderByIdQuery: IRequest<OrderViewModel>
    {
        public Guid OrderId { get; set; }
    }
}
