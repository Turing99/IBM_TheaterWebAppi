using IBM_TheaterWebAppi.Context;
using IBM_TheaterWebAppi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository 
    {
        private readonly TheaterContext _context;

        public ActorRepository(TheaterContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
