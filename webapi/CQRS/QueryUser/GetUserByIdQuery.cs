using MediatR;
using webapi.CQRS.ViewModels;

namespace webapi.CQRS.QueryUser
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public Guid UserId { get; set; }
    }
}
