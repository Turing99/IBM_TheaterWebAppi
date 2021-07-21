using IBM_TheaterWebAppi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.UnitsOfWork
{
    public interface ITheaterUnitOfWork : IDisposable 
    {

        ITheaterRepository Theaters { get; }

        IActorRepository Actors { get; }

        int Complete();
    }
}
