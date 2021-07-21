using IBM_TheaterWebAppi.Context;
using IBM_TheaterWebAppi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TheaterContext _context;

        public UserRepository(TheaterContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}
