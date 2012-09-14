using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Data.Context;

namespace ToDo.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
        User GetByEmail(string email);
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IToDoContextProvider ctx) : base(ctx)
        {
        }

        public User GetByUsername(string username)
        {
            return Query().SingleOrDefault(x => x.Username == username);
        }

        public User GetByEmail(string email)
        {
            return Query().SingleOrDefault(x => x.Email == email);
        }
    }
}
