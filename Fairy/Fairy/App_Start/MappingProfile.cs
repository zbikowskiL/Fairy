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

            //Section Domain => DTO\\
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Book, BookDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();


            //Section DTO => Domain\\
            Mapper.CreateMap<CustomerDTO, Customer>();
            Mapper.CreateMap<MembershipTypeDTO, MembershipType>();
            Mapper.CreateMap<BookDTO, Book>();
            Mapper.CreateMap<GenreDTO, Genre>();

            

        }
    }
}