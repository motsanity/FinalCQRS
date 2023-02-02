using MediatR;
using webapi.CQRS.ViewModels;

namespace webapi.CQRS.QueryOrder
{
    public class GetAllOrderByStatusQuery : IRequest<IEnumerable<OrderViewModel>>
    {
        public short Status { get; set; }
    }
}
