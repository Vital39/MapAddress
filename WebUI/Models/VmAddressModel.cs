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
              
                List<AddressDTO> mas = (numHouse!=String.Empty) ? 
                    addressService.FindBy(x => x.House.Contains(numHouse) && x.StreetName.Contains(item)).ToList() 
                    : addressService.FindBy(x => x.StreetName.Contains(item)).ToList();
                
                if(mas!=null)
                    addresses.AddRange(mas);

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
        private bool FilterAddress(string value, string requestStr)
        {
            var masRes = value.Split(new char[] { ' ','-','/' }, StringSplitOptions.RemoveEmptyEntries);
            var masReq = value.Split(new char[] { ' ', '-', '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var res in masRes)
            {
                foreach (var req in masReq)
                {
                    if (req.ToLower().IndexOf(res.ToLower()) == 0)
                        return true;
                }
            }
            return false;
        }
    }

}