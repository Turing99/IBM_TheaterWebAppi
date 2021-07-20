using IBM_TheaterWebAppi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Context
{
    public class TheaterContext : DbContext
    {

        public TheaterContext(DbContextOptions<TheaterContext> options)
          : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Theater> Theaters { get; set; }

    }
}
