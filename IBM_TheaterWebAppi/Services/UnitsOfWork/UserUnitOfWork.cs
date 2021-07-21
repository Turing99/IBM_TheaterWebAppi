using IBM_TheaterWebAppi.Context;
using IBM_TheaterWebAppi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.UnitsOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly TheaterContext _context;

        public UserUnitOfWork(TheaterContext context, IUserRepository users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Users = users ?? throw new ArgumentNullException(nameof(context));
        }


        public IUserRepository Users { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
