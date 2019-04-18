using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class AddressModel
    {
        IGenericService<AddressDTO> addressService;
        IGenericService<StreetDTO> streetService;
        IGenericService<SubdivisionDTO> subdivisionService;

        public AddressModel(IGenericService<AddressDTO> addressService, IGenericService<StreetDTO> streetService, IGenericService<SubdivisionDTO> subdivisionService)
        {
            this.addressService = addressService;
            this.streetService = streetService;
            this.subdivisionService = subdivisionService;
        }
        public List<string> GetAddresses(string requestStr)
        {
            var streets = streetService.FindBy(x => x.StreetName.Contains(requestStr)).ToList();

            List<string> strs = new List<string>();

            streets.ForEach(street => strs.AddRange(
                addressService.FindBy(
                    x => x.StreetId == street.StreetId)
                    .Select(x => street.StreetName + " " + x.House)));
            return strs;
        }
    }
    public static class StringExtension
    {
        public static bool FindInStr(this string value, string requestStr)
        {
            var masRes = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in masRes)
            {
                if (item.IndexOf(requestStr) == 0)
                    return true;
            }
            return false;
        }
    }
}