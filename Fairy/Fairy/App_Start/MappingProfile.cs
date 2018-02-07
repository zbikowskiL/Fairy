using AutoMapper;
using Fairy.DTOmodels;
using Fairy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fairy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();


            Mapper.CreateMap<CustomerDTO, Customer>();

        }
    }
}