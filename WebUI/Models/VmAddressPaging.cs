using BLL.Interfaces;
using BLL.Models;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WebUI.Models
{
    public class VmAddressPaging
    {
        private IGenericService<AddressDTO> addressesService;
        private IEnumerable<AddressDTO> addresses;
        public PagingInfo Paging { get; set; }
        public int CurrentPageProp { private get; set; }


        public VmAddressPaging(IGenericService<AddressDTO> addressesService)
        {
            this.addressesService = addressesService;
            addresses = addressesService.FindBy(Predicate);
            Paging = new PagingInfo() { ItemsPerPage = 20, CurrentPage = CurrentPageProp };
            Paging.TotalItems = addresses.Count();
        }


        public IEnumerable<AddressDTO> Addresses
        {
            get
            {
                return addresses.OrderBy(c => c.StreetName).Skip((Paging.CurrentPage - 1) * Paging.ItemsPerPage).Take(Paging.ItemsPerPage);
            }
        }

        Expression<Func<AddressDTO, bool>> Predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<AddressDTO>(true);
                predicate = predicate.And(c => c.AddressId <= CurrentPageProp * Paging.ItemsPerPage && c.AddressId > CurrentPageProp * Paging.ItemsPerPage - Paging.ItemsPerPage);
                return predicate;
            }
        }
    }
}