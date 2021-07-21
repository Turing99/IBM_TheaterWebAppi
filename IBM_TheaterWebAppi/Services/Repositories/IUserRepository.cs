using IBM_TheaterWebAppi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();

    }
}
