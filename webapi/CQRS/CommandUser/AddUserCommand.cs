using MediatR;

namespace webapi.CQRS.CommandUser
{
    public class AddUserCommand: IRequest<Guid>
    {
        public string? UserName { get; set; }

    }
}
 