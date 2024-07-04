using API_DTO.DTO;
using API_DTO.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DTO.MapConfig
{
    public class MapProfile : Profile
    {
        public Mapper GetMapper()
        {
            var config = new MapperConfiguration(c => { 
                c.CreateMap<users, UserDTO>();
                c.CreateMap<UserDTO, users>();
                });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}