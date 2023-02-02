using MediatR;

namespace webapi.CQRS.CommandCartItem
{
    public class AddCartItemCommand: IRequest<Guid> //added 4:33pm 1/24/2023
    {
        public string? CartItemName { get; set; }
        public Guid CustomerId { get; set; }


    }
}
 