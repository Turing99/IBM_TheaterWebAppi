using IBM_TheaterWebAppi.Context;
using IBM_TheaterWebAppi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Services.Repositories
{
    public class TheaterRepository : Repository<Theater>, ITheaterRepository
    {
        private readonly TheaterContext _context;

        public TheaterRepository(TheaterContext context): base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Theater GetTheaterDetails(Guid theaterId)
        {
            return _context.Theaters
                .Where(t => t.ID == theaterId && (t.Deleted == false || t.Deleted == null))
                .Include(t => t.Actor)
                .FirstOrDefault();
        }
    }
}
