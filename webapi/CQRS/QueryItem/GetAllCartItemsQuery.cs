using MediatR;
using webapi.CQRS.ViewModels;

namespace webapi.CQRS.QueryItem
{
    public class GetAllCartItemsQuery : IRequest<List<CartItemViewModel>>
    {

    }
}
