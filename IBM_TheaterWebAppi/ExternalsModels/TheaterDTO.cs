using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.ExternalsModels
{
    public class TheaterDTO
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public int Phone { get; set; }

        public Guid ActorId { get; set; }
    }
}
