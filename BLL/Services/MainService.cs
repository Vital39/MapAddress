using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BLL.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MainService<DOMAIN, DTO> : IGenericService<DOMAIN, DTO> where DOMAIN : class, new() where DTO : class, new()
    {
        private IGenericRepository<DOMAIN> repository;
        protected IMapper mapper;

        public MainService(IGenericRepository<DOMAIN> repository)
        {
            this.repository = repository;
            InitAutoMapper();
        }

        protected virtual void InitAutoMapper()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<DOMAIN, DTO>();
                cfg.CreateMap<DTO, DOMAIN>();

            }).CreateMapper();
        }

        public DTO Add(DTO obj)
        {
            DOMAIN address = mapper.Map<DOMAIN>(obj);
            repository.AddOrUpdate(address);
            repository.Save();
            return mapper.Map<DTO>(address);
        }

        public DTO Delete(int id)
        {
            DOMAIN address = repository.Get(id);
            repository.Delete(address);
            repository.Save();
            return mapper.Map<DTO>(address);
        }

        public IEnumerable<DTO> FindBy(Expression<Func<DTO, bool>> predicate)
        {
            try
            {
                var predicateFilm = mapper.Map<Expression<Func<DOMAIN, bool>>>(predicate);
                return repository.FindBy(predicateFilm)
                    .Select(obj => mapper.Map<DTO>(obj));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public DTO Get(int id)
        {
            DOMAIN address = repository.Get(id);
            return mapper.Map<DTO>(address);
        }

        public IEnumerable<DTO> GetAll()
        {
            return repository.GetAll().Select(obj => mapper.Map<DTO>(obj));
        }

        public DTO Update(DTO obj)
        {
            DOMAIN address = mapper.Map<DOMAIN>(obj);
            repository.AddOrUpdate(address);
            repository.Save();
            return mapper.Map<DTO>(address);
        }
    }
}
