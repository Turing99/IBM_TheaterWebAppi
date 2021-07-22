using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Profiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            CreateMap<Entities.Actor, ExternalsModels.ActorDTO>();
            CreateMap<ExternalsModels.ActorDTO, Entities.Actor>();

            CreateMap<Entities.Theater, ExternalsModels.TheaterDTO>();
            CreateMap<ExternalsModels.TheaterDTO, Entities.Theater>();
        }
    }
}
