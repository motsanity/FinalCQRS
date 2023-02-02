using Microsoft.EntityFrameworkCore;
using Dapper;
using AutoMapper;
using webapi.Domain.Models;
using webapi.Infrastructure.Database.Contexts;
using webapi.Domain.Contracts;
using System.Drawing;

namespace webapi.Infrastructure.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddUser(UserModel user)
        {
            var entity = _mapper.Map<Entities.User>(user);
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

            return entity.UserId;
        }

        public async Task<UserModel> GetUserById(Guid userId)
        {
            var query = "SELECT * FROM Users WHERE UserId = @userId";

            using (var connection = _context.Database.GetDbConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<UserModel>(query, new { userId });

                return user;

            }
        }

        public async Task UpdateUser(Guid UserId, string username) //added 1:28PM 1/24/2023
        {
            var entity = await FindUserById(UserId);
            entity.UserName = username;
            await _context.SaveChangesAsync();

        }


        private async Task<Entities.User> FindUserById(Guid id) //added 1:37PM 1/24/2023
        {
            var found = await _context.Users.FindAsync(id);
            if (found == null)
                throw new NullReferenceException();

            return found;
        }


    }
}
