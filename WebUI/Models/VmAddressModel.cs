using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebUI.Models
{
    public class VmAddressModel
    {
        IGenericService<AddressDTO> addressService;


        public VmAddressModel(IGenericService<AddressDTO> addressService)
        {
            this.addressService = addressService;
        }
          
        public List<string> GetAddresses(string requestStr)
        {
            List<string> filterAddresses = new List<string>();
            List<AddressDTO> addresses=new List<AddressDTO>();
            string numHouse = Regex.Replace(requestStr, @"[^\d]+", "");

            var masReq=requestStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
          
            foreach (var item in masReq)
            {
                List<AddressDTO> mas = addressService.FindBy(x => x.StreetName.Contains(item)).ToList();
                if(mas!=null)
                    addresses.AddRange(mas);

            }

            if (numHouse != String.Empty)
            {
                addresses.AddRange(addressService.FindBy(x => x.House.Contains(numHouse)).ToList());
                filterAddresses = addresses.FindAll(x => FilterAddress(x.House, requestStr))
                   .Select(x => x.StreetName + " " + x.House).ToList();
            }
            if (addresses != null)
            {
                filterAddresses.AddRange(addresses.FindAll(x => FilterAddress(x.StreetName, requestStr))
                    .Select(x => x.StreetName + " " + x.House).ToList());

                filterAddresses.Sort();
                return filterAddresses;
            }
            else return null;

        }
        public bool FilterAddress(string value, string requestStr)
        {
            var masRes = value.Split(new char[] { ' ','-','/' }, StringSplitOptions.RemoveEmptyEntries).Skip(1);

            foreach (var item in masRes)
            {
                if (item.ToLower().IndexOf(requestStr.ToLower()) == 0)
                    return true;
            }
            return false;
        }
    }

}