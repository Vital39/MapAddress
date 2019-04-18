using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class VmAddressPaging
    {
        private IGenericService<AddressDTO> addressesService;
        private IEnumerable<AddressDTO> addresses;
        public PagingInfo Paging { get; set; }

        public VmAddressPaging(IGenericService<AddressDTO> addressesService, int currentPage)
        {
            this.addressesService = addressesService;
            addresses = addressesService.GetAll();
            Paging = new PagingInfo() { ItemsPerPage = 10, CurrentPage = currentPage };
            Paging.TotalItems = addresses.Count();
        }


        public IEnumerable<AddressDTO> Addresses
        {
            get
            {
                return addresses.OrderBy(c => c.StreetName).Skip((Paging.CurrentPage - 1) * Paging.ItemsPerPage).Take(Paging.ItemsPerPage);
            }
        }
    }
}