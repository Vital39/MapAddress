using Autofac;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL.DbLayer;
using DAL.Repository;
using Repository.Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Modules
{
    public partial class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Address
            builder.RegisterType(typeof(AddressService))
              .As(typeof(IGenericService<AddressDTO>));
            builder.RegisterType(typeof(MainRepository<Address>))
                      .As(typeof(IGenericRepository<Address>));

            //Street
            builder.RegisterType(typeof(StreetService))
                        .As(typeof(IGenericService<StreetDTO>));
            builder.RegisterType(typeof(MainRepository<Street>))
                      .As(typeof(IGenericRepository<Street>));

            //Subdivision
            builder.RegisterType(typeof(SubdivisionService))
                        .As(typeof(IGenericService<SubdivisionDTO>));
            builder.RegisterType(typeof(MainRepository<Subdivision>))
                      .As(typeof(IGenericRepository<Subdivision>));

            
            builder.RegisterType(typeof(AddressContext))
                     .As(typeof(DbContext)).InstancePerLifetimeScope();
        }
    }
}
