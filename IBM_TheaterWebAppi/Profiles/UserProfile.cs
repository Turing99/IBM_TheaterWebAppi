﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBM_TheaterWebAppi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, ExternalsModels.UserDTO>();
            CreateMap<ExternalsModels.UserDTO, Entities.User>();
        }
    }
}
