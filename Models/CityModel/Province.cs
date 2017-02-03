using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab5.Models.CityModel
{
    public class Province
    {
        [Key]
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        
        public List<City> Cities { get; set; }
    }
}