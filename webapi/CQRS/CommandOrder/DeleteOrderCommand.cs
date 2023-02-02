using MediatR;

namespace webapi.CQRS.CommandOrder
{
    public class DeleteOrderCommand: IRequest
    {
        public Guid OrderId { get; set; }
    }
}
