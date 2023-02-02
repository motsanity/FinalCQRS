
namespace webapi.AppService.Operation.Middleware
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        protected readonly webapi.Infrastructure.Database.Contexts.AppDbContext _context; 
        public BasicAuthMiddleware(RequestDelegate next, webapi.Infrastructure.Database.Contexts.AppDbContext context)
        {
            _next = next;
            _context = context;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("x-user-id"))
            {
                context.Response.StatusCode = 401;
                return;
            }
            string userId = context.Request.Headers["x-user-id"];
            Guid parsedUserId = Guid.Parse(userId); if (!IsValidUserId(parsedUserId))
            {
                context.Response.StatusCode = 401;
                return;
            }
            await _next(context);
        }
        private bool IsValidUserId(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       

    }
    
}