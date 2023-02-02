using MediatR;

namespace webapi.CQRS.CommandCartItem
{
    public class DeleteCartItemCommand : IRequest
    {
        public Guid CartItemId { get; set; }
    }
}
