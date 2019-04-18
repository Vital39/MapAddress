using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BLL.Models;
using DAL.DbLayer;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AddressService : MainService<Address, AddressDTO>
    {
        public AddressService(IGenericRepository<Address> repository) : base(repository)
        {
            
        }

        protected override void InitAutoMapper()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Address, AddressDTO>()
                 .ForMember("StreetName", opt => opt.MapFrom(g => g.Street.StreetName))
                 .ForMember("SubdivisionName", opt => opt.MapFrom(g => g.Subdivision.SubdivisionName))
                 ;
                cfg.CreateMap<AddressDTO, Address>();

            }).CreateMapper();
        }
    }
}
