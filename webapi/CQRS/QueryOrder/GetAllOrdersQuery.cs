using MediatR;
using webapi.CQRS.ViewModels;



namespace webapi.CQRS.QueryOrder
{
    public class GetAllOrdersQuery: IRequest<IEnumerable<OrderViewModel>>
    {
    }
}
