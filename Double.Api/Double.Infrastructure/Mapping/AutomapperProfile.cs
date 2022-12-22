using AutoMapper;
using Double.Core.DTOs;
using Double.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {

            CreateMap<Person, PersonDTOs>();
            CreateMap<PersonDTOs, Person>();

            CreateMap<TypeIdenti, TypeIdentiDTOs>();
            CreateMap<TypeIdentiDTOs, TypeIdenti>();

            CreateMap<User, UserDTOs>();
            CreateMap<UserDTOs, User>();

        }
    }
}
