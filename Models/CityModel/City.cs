using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab5.Models.CityModel
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int Population { get; set; }

        public string ProvinceCode { get; set; }
        public Province Province { get; set; }
    }
}