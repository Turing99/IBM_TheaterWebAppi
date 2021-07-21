using IBM_TheaterWebAppi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.Repositories
{
   public interface ITheaterRepository: IRepository<Theater>
    {
        Theater GetTheaterDetails(Guid theaterId);
    }
}
