using IBM_TheaterWebAppi.Context;
using IBM_TheaterWebAppi.Entities;
using IBM_TheaterWebAppi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.UnitsOfWork
{
    public class TheaterUnitOfWork : ITheaterUnitOfWork
    {
        private readonly TheaterContext _context;

        public TheaterUnitOfWork(TheaterContext context, ITheaterRepository theters,
            IActorRepository actors)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Theaters = theters ?? throw new ArgumentNullException(nameof(context));
            Actors = actors ?? throw new ArgumentNullException(nameof(context));
        }

        public ITheaterRepository Theaters { get; }

        public IActorRepository Actors { get; }

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
